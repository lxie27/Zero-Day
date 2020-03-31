using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    // the door from this object
    public GameObject DoorClosed;
    // the door copied and rotated/moved to be the opened door
    public GameObject DoorOpen;
    public Interactable trigger = null;

    // this is the movement rate (if movemnt is applied to the door)
    public float moveSpeed = 3;
    // this is the rotation rate (if rotation is applied to the door)
    public float rotationSpeed = 90;

    void Start()
    {
        DoorOpen.SetActive(false);
    }

    void Update()
    {
        if (trigger.on)
        {
            DoorClosed.transform.position = Vector3.MoveTowards(DoorClosed.transform.position, DoorOpen.transform.position, moveSpeed * Time.deltaTime);
            DoorClosed.transform.rotation = Quaternion.RotateTowards(DoorClosed.transform.rotation, DoorOpen.transform.rotation, rotationSpeed * Time.deltaTime);
            DoorClosed.SetActive(false);
        }
    }
}

