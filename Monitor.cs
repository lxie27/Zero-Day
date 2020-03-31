using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monitor : MonoBehaviour
{

    public List<GameObject> buttons;
    public List<Material> materials;
    public List<ListWrapper> screenHints;

    private int currentActive = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentActive = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].GetComponent<LaserButton>().on)
            {
                this.GetComponent<Renderer>().material = materials[i];
                foreach (Interactable obj in screenHints[currentActive].list)
                {
                    obj.gameObject.transform.parent.gameObject.SetActive(false);
                    obj.active = false;
                }
                foreach (Interactable obj in screenHints[i].list) {
                    if (obj.gameObject.GetComponent<Interactable>().found)
                    {
                        obj.gameObject.transform.parent.gameObject.SetActive(true);
                        obj.active = true;
                    }
                }
                currentActive = i;
            }
        }
    }
}
