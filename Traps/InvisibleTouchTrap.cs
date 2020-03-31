using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleTouchTrap : MonoBehaviour
{

    public GameObject Player;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Renderer>().enabled = false;

    }

    // On impact, an event can be triggered
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.transform.SetPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        }
    }
}
