using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    public GameObject thisScreen;

    void Start()
    {

    }

    public void Back()
    {
        thisScreen.gameObject.SetActive(false);
    }
}
