using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCTV_Laser : MonoBehaviour
{

    public CCTV cctv;
    public GameObject laser;

    // Update is called once per frame
    void Update()
    {
        if (cctv.active == false)
        {
            laser.SetActive(false);
        }

        else
        {
            laser.SetActive(true);
        }
    }
}
