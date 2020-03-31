using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningDoor : MonoBehaviour
{
	// Ability to set trap to visible or invisible
	public bool invisible;

	// Directions the door will move to
	public Vector3 close = new Vector3(-2, 0, 0);
	public Vector3 open = new Vector3(2, 0, 0);

    // Is this door locked
    public bool locked;

	public Transform Player;

	// Start is called before the first frame update
	void Start()
	{
		setVis();
        //locked = false;

        
	}

    // Change to MOVING Door
    private void FixedUpdate()
    {
        Vector3 directionToTarget = close - Player.position;
        float distance = directionToTarget.magnitude;
    

        if (distance > 5)
        {
           transform.localPosition = close;
        }

        if (locked)
        {
            transform.localPosition = close;
        }

        if (!(distance > 5) && !locked)
        {
            transform.localPosition = open;
            
        }
        
    }


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
