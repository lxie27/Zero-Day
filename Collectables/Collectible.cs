using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Collectible : MonoBehaviour
{
    public string keyName;
    public float bounceHeight = .1f;
    public float bounceSpeed = 1f;
    public float rotSpeed = 10.0f;
    private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(originalPos.x, originalPos.y + Mathf.Sin(Time.time) * bounceHeight, originalPos.z);
        transform.Rotate(0, 20 * rotSpeed * Time.deltaTime, 0);
    }
}
