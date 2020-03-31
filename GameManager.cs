using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Unlock Cursor Lock State
        Cursor.lockState = CursorLockMode.None;
        //Set Cursor to not be visible
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
