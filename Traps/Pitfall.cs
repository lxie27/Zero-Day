using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitfall : MonoBehaviour
{
    // the door from this object
    public GameObject ClosedTrap1;
    public GameObject ClosedTrap2;
    public GameObject ClosedTrap3;
    public GameObject ClosedTrap4;
    // this controls if the door is opened or closed.
    public bool isOn = false;
    

    void Start()
    {
    }

    void Update()
    {
      
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && isOn)
        {
            other.GetComponent<Rigidbody>().AddForce(new Vector3(0, -100, 0));
            isOn = false;
            ClosedTrap1.SetActive(false);
            ClosedTrap2.SetActive(false);
            ClosedTrap3.SetActive(false);
            ClosedTrap4.SetActive(false);
        }
    }
}
