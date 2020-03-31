using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionDropdown : MonoBehaviour
{
    Dropdown m_Dropdown;

    void Start()
    {
        //Fetch the Dropdown GameObject
        m_Dropdown = GetComponent<Dropdown>();
        //Add listener for when the value of the Dropdown changes, to take action
        m_Dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(m_Dropdown);
        });
        
    }

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(Dropdown change)
    {
        if (change.value == 0)
        {
            Screen.SetResolution(1920, 1440, false);
        }
        else if (change.value == 1)
        {
            Screen.SetResolution(1440, 1080, false);
        }
        else if (change.value == 2)
        {
            Screen.SetResolution(1080, 720, false);
        }

    }
}
