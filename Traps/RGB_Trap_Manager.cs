using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGB_Trap_Manager : MonoBehaviour
{
    public RGB_Button red;
    public RGB_Button green;
    public RGB_Button blue;

    public GameObject trap;
    public OpeningDoor door;

    bool activated;

    bool rActive;
    bool gActive;
    bool bActive;

    // Trap will be deactivated following BRG pattern
    void Update()
    {
        if (activated)
        {
            trap.SetActive(false);
            door.locked = false;
        }

        if (red.isLit() && green.isLit() && blue.isLit() && !activated)
        {
            red.setOff();
            green.setOff();
            blue.setOff();
            rActive = false;
            gActive = false;
            bActive = false;
        }

        if (blue.isLit() && !red.isLit() && !green.isLit())
        {
            bActive = true;
        }

        if (red.isLit() && bActive && !green.isLit())
        {
            rActive = true;
            activated = true;
        }

        if (green.isLit() && bActive && rActive && activated)
        {
            gActive = true;
            trap.SetActive(false);
            door.locked = false;
        }

    }
}
