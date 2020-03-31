using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingFloorTrap : MonoBehaviour
{

    public GameObject Player;

    public bool invisible;

    // Start is called before the first frame update
    void Start()
    {
        setVis();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.transform.SetPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        }
    }

    void setVis()
    {
        if (invisible == true)
        {
            GetComponent<Renderer>().enabled = false;
        }

        else
        {
            GetComponent<Renderer>().enabled = true;
        }
    }
}
