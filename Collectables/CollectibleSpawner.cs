using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject coll;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(coll, new Vector3(0, 0, -55f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
