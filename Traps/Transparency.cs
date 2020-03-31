using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparency : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color col = gameObject.GetComponent<Renderer>().material.color;
        col.a = .5f;
        gameObject.GetComponent<Renderer>().material.color = col;
    }
    
}
