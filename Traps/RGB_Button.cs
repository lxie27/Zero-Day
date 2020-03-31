using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGB_Button : MonoBehaviour
{
    public bool red;
    public bool green;
    public bool blue;

    public GameObject button;

    //public Renderer rend = button.GetComponent<Renderer>().material

    public bool lit;

    // Start is called before the first frame update
    void Start()
    {
        //button.GetComponent<Renderer>().material.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (lit)
        {
            button.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            baseColor();
        }

    }

    void baseColor()
    {
        if (red)
            button.GetComponent<Renderer>().material.color = Color.red;
        if (green)
            button.GetComponent<Renderer>().material.color = Color.green;
        if (blue)
            button.GetComponent<Renderer>().material.color = Color.blue; 
    }

    public void setLit()
    {
        lit = true;
    }

    public void setOff()
    {
        lit = false;
    }

    public bool isLit()
    {
        if (lit == true)
        {
            return true;

        }
        else
        {
            return false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            lit = true;
        }
    }


}
