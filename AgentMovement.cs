using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AgentMovement : MonoBehaviour
{
    //agent base movespeed
    public float moveSpeed;
    private float currentSpeed;
    
    //constants for speed modifiers
    private float sprintSpeed = 2.5f;
    private float crouchSpeed = .3f;
    
    // sets the player spawn location
    public Vector3 spawn;

    //force of agent jump
    public float jumpForce;

    //flag for locking mouse, defaults to locked
    private bool cursorLocked;

    //rigidbody of the agent
    public Rigidbody rb;
    //camera attached to this agent
    private Camera cam;

    //checks if player is in the air already *** NEEDS TO BE UPDATED LATER
    private float distToGround;

    //maximum number of jumps in one jump allotted
    private int maxJumps;
    private int currJumps;

    //artificial gravity for the player - used to make jump more 'snappy'
    private float grav = 9.8f;
    public float gravScale = 3f;
        
    //Fisheyeing on sprinting
    private float originalFOV;
    private float fishEyeFOV;
    private float originalHeight;
    private float crouchAmount = .25f;
    private float crouchHeight;
    private bool isCrouched;
    private bool isInDuct;
    ////bigger -> larger bounces
    //private float shakeMagnitude = 1f;
    ////0f - > 1f, bigger is less smooth
    //private float shakeSmoothness = 0.1f;

    //private bool isCrouching = false;
    // If player touches this, level is finished.
    //public GameObject endObject;
    //public GameObject endTextObject;
    public UnityEngine.UI.Image deathScreen;
    public Text winText;

    public List<GameObject> inventory;

    AudioSource m_MyAudioSource;

    float flashTime = .5f;
    void Start()
    {
        //Fetch the AudioSource from the GameObject
        m_MyAudioSource = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
        m_MyAudioSource.Stop();

        //pressing escape unlocks the cursor for pausing
        //Cursor.lockState = CursorLockMode.Locked;
        //cursorLocked = true;
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        spawn = this.transform.position;

        distToGround = GetComponent<Collider>().bounds.extents.y;
        currJumps = 0;
        maxJumps = 2;
        currentSpeed = 10f;

        //originalFOV = cam.fieldOfView;
        fishEyeFOV = originalFOV * 1.1f;

        Cursor.lockState = CursorLockMode.Locked;
        cursorLocked = true;
        
        originalHeight = this.transform.localScale.y;
        crouchHeight = originalHeight * crouchAmount;

        isCrouched = false;
        isInDuct = false;
        
        //StartCoroutine(PauseAtStart());
        
        //shakeMagnitude = 1f;

        //endTextObject.SetActive(false);

    }

    private IEnumerator PauseAtStart()
    {
        Color black = new Color(0.0f, 0.0f, 0.0f, 1f);
        Color transparent = new Color(0f, 0.0f, 0.0f, 0f);
        deathScreen.color = black;
        yield return new WaitForSeconds(1f);
        deathScreen.color = transparent;
    }
    
    void Update()
    {
        Vector3 vel = rb.velocity;
        vel.y -= gravScale * grav * Time.deltaTime;
        rb.velocity = vel;

        if (isCrouched)
        {
            currentSpeed = moveSpeed * crouchSpeed;
        }
        //movement
        float translation = Input.GetAxis("Vertical") * currentSpeed;
        float strafe = Input.GetAxis("Horizontal") * currentSpeed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);

        //if agent is on the ground
        if (isGrounded())
        {
            //reset allotted jumps
            currJumps = 2;
        }

        //TODO: current glitch with jumping, spamming the jump at second jump allows triple jumping
        //if spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if the player jumps from the ground OR if the player still has jumps available
            if (isGrounded() || currJumps < maxJumps)
            {
                currJumps += 1;
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
                rb.AddForce(new Vector3(0, jumpForce * rb.mass, 0), ForceMode.Impulse);
            }
        }
        
        
        //on sprint
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && !isCrouched && !isInDuct)
        {
            currentSpeed = moveSpeed * sprintSpeed;
            //fisheye on sprint
            //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fishEyeFOV, 10 * Time.deltaTime);
        }

        //on crouch
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouched = true;
            currentSpeed = moveSpeed * crouchSpeed;
            //shorten model on crouch
            this.transform.localScale = new Vector3(this.transform.localScale.x, crouchHeight, this.transform.localScale.z);
        }
        //check if the player is in the duct before letting them snap back to normal height
        else if (Input.GetKeyUp(KeyCode.LeftControl) && !isInDuct)
        {
            //check if the player is in the duct before letting them snap back to normal height
            this.transform.localScale = new Vector3(this.transform.localScale.x, originalHeight, this.transform.localScale.z);
            isCrouched = false;
        }
        //return player to normal speed if not crouching / sprinting
        else
        {
            currentSpeed = moveSpeed;
            //revert back to original fov on release
            //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, originalFOV, 10 * Time.deltaTime);
        }

        //edge case if player released crouch button while in duct and then leaves duct, should pop them to normal size
        if (!isCrouched && !isInDuct)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, originalHeight, this.transform.localScale.z);
        }

        // hit escape to unlock cursor
        if (Input.GetKeyDown(KeyCode.Escape)) {
            //if the cursor is locked, unlock it
            if (cursorLocked)
                Cursor.lockState = CursorLockMode.None;
            //if the cursor is unlocked, lock it
            else
                Cursor.lockState = CursorLockMode.Locked;
            //flip the flag to opposite state
            cursorLocked = !cursorLocked;
        }

        //Debug.Log("current speed is " + currentSpeed);
    }

    //does a raycast under object to see if there's anything underneath
    bool isGrounded()
    {
        //returns true if body is .05f or less from the ground
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.05f);
    }

    //public IEnumerator CameraShake()
    //{
    //    Vector3 camOriginalPos = cam.transform.localPosition;

    //    while (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
    //    {
    //        Debug.Log("Shaking");
    //        cam.transform.localPosition = new Vector3(
    //            Mathf.Sin(Time.deltaTime * shakeMagnitude),
    //            Mathf.Sin(Time.deltaTime * shakeMagnitude),
    //            cam.transform.localPosition.z);

    //        yield return null;
    //    }
    //}


    void OnTriggerEnter(Collider other)
    {
        //if (other == endObject)
        //{
        //    endTextObject.SetActive(true);
        //}
        if (other.tag == "Trap")
        {
            StartCoroutine(ScreenFlash());
            transform.position = spawn;
        }
        if (other.tag == "Collectible")
        {
            Debug.Log("Collected");
            inventory.Add(other.gameObject);
            other.gameObject.SetActive(false);
            Debug.Log(inventory[0].GetComponent<Collectible>().keyName);
        }
        if (other.tag == "Duct")
        {
            isInDuct = true;
        }
        if (other.tag == "Finish")
        {
            foreach(GameObject key in inventory)
            {
                if (key.name == "exit_keycard")
                {
                    winText.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Duct")
        {
            isInDuct = false;
        }
    }

    private IEnumerator ScreenFlash()
    {
        Color darkred = new Color(.8f, 0.0f, 0.0f, .3f);
        Color transparent = new Color(0f, 0.0f, 0.0f, 0f);

        deathScreen.color = darkred;
        m_MyAudioSource.Play();
        yield return new WaitForSeconds(1f);

        deathScreen.color = transparent;

    }
}
