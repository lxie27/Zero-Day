using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject location;
    public AgentMovement agent;

    public Transform spawnpoint;

    private void Start()
    {
        spawnpoint = location.transform;
        spawnpoint.position = new Vector3(spawnpoint.transform.position.x, spawnpoint.transform.position.y - 1, spawnpoint.transform.position.z);

    }

    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform == agent.transform)
        {
       
            agent.spawn = spawnpoint.position;
            

        }
    }
}
