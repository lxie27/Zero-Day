using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dial : Interactable
{
    // Update is called once per frame
    void Update()
    {
        if (this.transform.rotation.y >= 90)
        {
            this.on = true;
            this.transform.rotation.Set(transform.rotation.x, 90, transform.rotation.z, transform.rotation.w);
        }
        if (this.transform.rotation.y < 0)
        {
            this.transform.rotation.Set(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
            this.on = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!on)
        {
            transform.Rotate(0, 90, 0);
            on = true;
        }
    }
}
