using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackerCam : MonoBehaviour
{
    //direction mouse is looking in
    Vector2 mouseLook;
    //smooths mouse movement
    Vector2 smoothVec;

    //is the camera focused on an object?
    bool isFocused;

    //sensitivity
    public float mouseSensitivity = 5.0f;

    //smoothing constant
    public float smoothing = 2.0f;

    //the player/object the camera is parented to
    GameObject parent;

    //values for min/max vertical looking (anti-neck breaking)
    private float minY = -70f;
    private float maxY = 80f;

    private Vector3 zoomView;

    private static Vector3 initPlace;

    public Switch switch1;
    public Switch switch2;
    public Switch switch3;

    void Start()
    {
        parent = this.transform.parent.gameObject;
        isFocused = false;
        initPlace = parent.transform.position;
    }

    void Update()
    {
        if (!isFocused)
        {
            var mouseDir = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            mouseDir = Vector2.Scale(mouseDir, new Vector2(mouseSensitivity * smoothing, mouseSensitivity * smoothing));
            smoothVec.x = Mathf.Lerp(smoothVec.x, mouseDir.x, 1f / smoothing);
            smoothVec.y = Mathf.Lerp(smoothVec.y, mouseDir.y, 1f / smoothing);

            mouseLook += smoothVec;
            //clamping vertical look limits (can't break neck looking up/down)
            mouseLook.y = Mathf.Clamp(mouseLook.y, minY, maxY);


            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            parent.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, parent.transform.up);
        }

        // if left button pressed...
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Monitor")
                {
                    isFocused = true;
                    zoomView = this.transform.parent.position + new Vector3(0,0,1);
                    //parent.transform.SetPositionAndRotation(hit.transform.position, new Quaternion(270, 0, 0, 0));
                    parent.transform.SetPositionAndRotation(zoomView, new Quaternion(0, 0, 0, 90));
                    
                }

                if (hit.transform == switch1.transform)
                {
                    switch1.unlockDoor();
                }

                if (hit.transform == switch2.transform)
                {
                    switch2.unlockDoor();
                }

                if (hit.transform == switch3.transform)
                {
                    switch3.unlockDoor();
                }
            }
        }
  
    }
}
