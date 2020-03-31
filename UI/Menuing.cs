using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOne : MonoBehaviour
{
    public void LoadSceneOnClick(string scene)
    {
        Application.LoadLevel(scene);
    }
}
