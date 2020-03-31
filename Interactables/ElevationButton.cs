using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevationButton : Interactable
{
    public GameObject controlledObject;
    float speedModifier = 1.5f;
    float sensitivityModifier = .01f;
    //type is up/down button, up is true, false is down
    public bool type;

    float originalYPosition;

    
    // Start is called before the first frame update
    void Start()
    {
        originalYPosition = this.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < originalYPosition - sensitivityModifier)
        {
            on = true;
            this.GetComponent<Rigidbody>().AddForce(0, 1, 0);
        }
        else
        {
            on = false;
        }

        if (on)
        {
            if (type)
            {
                controlledObject.transform.position =
                    new Vector3(controlledObject.transform.position.x, controlledObject.transform.position.y + (1f * speedModifier * Time.deltaTime), controlledObject.transform.position.z);
            }
            else
            {
                controlledObject.transform.position =
                    new Vector3(controlledObject.transform.position.x, controlledObject.transform.position.y - (1f * speedModifier * Time.deltaTime), controlledObject.transform.position.z);
            }
        }
    }
    
}
