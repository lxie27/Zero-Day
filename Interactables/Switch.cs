using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject trap;
    public OpeningDoor door;

    public GameObject switchButton;

    public bool on;
    public int timeToReset = 2;
   

    // Update is called once per frame
    void Update()
    {
        //rend.material.color = altColor;

        if (on)
        {
            trap.SetActive(false);
            door.locked = false;
            //altColor.r = 1.0f;
            //altColor.g = 1.0f;
            //altColor.b = 1.0f;
            switchButton.GetComponent<Renderer>().material.color = Color.white;


        }

        else
        {
            trap.SetActive(true);
            door.locked = true;
            //altColor.r = 0.0f;
            //altColor.g = 0.0f;
            //altColor.b = 0.0f;
            switchButton.GetComponent<Renderer>().material.color = Color.magenta;
        }
            

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            on = true;
            Invoke("SetOff", timeToReset);

        }
    }


    public void unlockDoor()
    {
        
        on = true;
        Invoke("SetOff", timeToReset);
        

    }

    private void SetOff()
    {
        on = false;

    }
}
