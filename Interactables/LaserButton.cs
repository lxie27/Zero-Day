using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserButton : Interactable
{
    public Rigidbody button;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            button.AddForce(new Vector3(-10, 0, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Button")
        {
            on = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Button")
        {
            on = false;
        }
    }
}
