using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    // Ability to set trap to visible or invisible
    public bool invisible;

    // Distance the trap will move
    //public float distance = 4.0f;

    // Speed at which the trap will move
    public float speed = 1.0f;

    // Directions the trap will move to
    public Vector3 pos1 = new Vector3(-2, 0, 0);
    public Vector3 pos2 = new Vector3(2, 0, 0);

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        setVis();
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));

    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        Player.transform.SetPositionAndRotation(new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
    //    }
    //}

    // Sets the trap visible or invisible 
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
