using UnityEngine;
using System.Collections;

public class AgentCam : MonoBehaviour
{
    //direction mouse is looking in
    Vector2 mouseLook;
    //smooths mouse movement
    Vector2 smoothVec;

    //sensitivity
    public float mouseSensitivity = 5.0f;

    //smoothing constant
    public float smoothing = 2.0f;

    //the player/object the camera is parented to
    GameObject agent;

    //values for min/max vertical looking (anti-neck breaking)
    private float minY = -70f;
    private float maxY = 80f;

    void Start()
    {
        agent = this.transform.parent.gameObject;
        UnityEngine.XR.XRSettings.showDeviceView = false;
    }

    void Update()
    {
        var mouseDir = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseDir = Vector2.Scale(mouseDir, new Vector2(mouseSensitivity * smoothing, mouseSensitivity * smoothing));
        smoothVec.x = Mathf.Lerp(smoothVec.x, mouseDir.x, 1f / smoothing);
        smoothVec.y = Mathf.Lerp(smoothVec.y, mouseDir.y, 1f / smoothing);

        mouseLook += smoothVec;
        //clamping vertical look limits (can't break neck looking up/down)
        mouseLook.y = Mathf.Clamp(mouseLook.y, minY, maxY);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        agent.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, agent.transform.up);
    }
}