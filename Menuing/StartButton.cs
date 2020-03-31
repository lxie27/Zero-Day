using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject levelSelectScreen;

    public void OpenLevelSelect()
    {
        levelSelectScreen.SetActive(true);
    }
}
