using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV : MonoBehaviour
{

    public bool active;

    public float speed = 2f;
    public float maxRotation = 45f;
    public float xRotation = -20f;


    private void Start()
    {
        active = true;

    }
    void Update()
    {
        if (active)
        {
            transform.rotation = Quaternion.Euler(-90f, 180f, maxRotation * Mathf.Sin(Time.time * speed));
            //transform.rotation = Quaternion.Euler(-90f, transform.position.x, maxRotation * Mathf.Sin(Time.time * speed));

        }
        
    }

    public void setInactive()
    {
        active = false;
    }
}
