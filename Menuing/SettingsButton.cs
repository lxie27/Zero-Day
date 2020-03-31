using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButton : MonoBehaviour
{
    public GameObject settingsScreen;

    void Start()
    {
        
    }
    public void OpenSettings()
    {
        settingsScreen.SetActive(true);
    }
}
