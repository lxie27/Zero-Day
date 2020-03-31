using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    public GameObject controlledObject;
    public GameObject joystickBall;
    public Rigidbody platformRB;

    Vector3 originalPosition;
    float speedModifier = 20f;
    float sensitivityModifier = .01f;

    float xDelta = 0;
    float zDelta = 0;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = joystickBall.transform.position;
        Debug.Log("position of ball: " + originalPosition);
    }

    void Update()
    {

        if (joystickBall.transform.position.z > originalPosition.z + sensitivityModifier
            || joystickBall.transform.position.z < originalPosition.z - sensitivityModifier)
        {
            zDelta = joystickBall.transform.position.z - originalPosition.z;
        }
        else
        {
            zDelta = 0;
        }
        if (joystickBall.transform.position.x > originalPosition.x + sensitivityModifier
            || joystickBall.transform.position.x < originalPosition.x - sensitivityModifier)
        {
            xDelta = joystickBall.transform.position.x - originalPosition.x;
        }
        else
        {
            xDelta = 0;
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (zDelta != 0)
        { 
            if (xDelta != 0)
            {
                if (zDelta >= xDelta)
                {
                    platformRB.MovePosition(platformRB.transform.position + transform.forward * zDelta * speedModifier * Time.deltaTime);
                }
                else
                {
                    platformRB.MovePosition(platformRB.transform.position + transform.right * xDelta * speedModifier * Time.deltaTime);
                }
            }
            else
            {
                platformRB.MovePosition(platformRB.transform.position + transform.forward * zDelta * speedModifier * Time.deltaTime);
            }
        }

        else if (xDelta != 0)
        {
            if (zDelta != 0)
            {
                if (xDelta >= zDelta)
                {
                    platformRB.MovePosition(platformRB.transform.position + transform.right * xDelta * speedModifier * Time.deltaTime);
                }
                else
                {
                    platformRB.MovePosition(platformRB.transform.position + transform.forward * zDelta * speedModifier * Time.deltaTime);
                }
            }
            else
            {
                platformRB.MovePosition(platformRB.transform.position + transform.right * xDelta * speedModifier * Time.deltaTime);
            }
        }
    }
}
