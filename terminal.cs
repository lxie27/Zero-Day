namespace Valve.VR.Extras
{ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class terminal : MonoBehaviour
{
    public UnityEngine.UI.Text hintText;
    public UnityEngine.UI.Text dialogueBox1;
    public UnityEngine.UI.Text dialogueBox2;
    public UnityEngine.UI.Text dialogueBox3;
    public UnityEngine.UI.Text nameBox;
    public string[] textDialogue;
    public string textName;
    public Animator animator;
    public bool on = false;
    public List<Interactable> interactables;
    bool isNearby = false;
    public SteamVR_Action_Boolean vrTrigger = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("InteractUI");
    SteamVR_Behaviour_Pose trackedObj;

    private int sentenceNumber = 0;
    private bool animatorIsOpen = false;

    AudioSource m_MyAudioSource;

    void Start()
    {
        //Fetch the AudioSource from the GameObject
        m_MyAudioSource = GetComponent<AudioSource>();
        //Ensure the toggle is set to true for the music to play at start-up
        m_MyAudioSource.Stop();
    }

    private void Update()
    {
        if (isNearby && Input.GetKeyDown(KeyCode.E))
        {
            m_MyAudioSource.Play();
            this.on = true;
            hintText.gameObject.SetActive(false);
            if (this.textDialogue.Length >= 0 && !animatorIsOpen)
            {
                animator.SetBool("IsOpen", true);
                animatorIsOpen = true;
                nameBox.text = textName;
                DisplayNextSentence();
            }
            foreach (Interactable interactable in interactables)
            {
                interactable.found = true;
                if (interactable.active)
                {
                    interactable.gameObject.transform.parent.gameObject.SetActive(true);
                }
            }
        }
        if (animatorIsOpen && Input.GetMouseButtonDown(0))
        {
            DisplayNextSentence();
        }
    }

    public void DisplayNextSentence()
    {
        if (this.sentenceNumber == this.textDialogue.Length)
        {
            EndDialogue();
            return;
        }
        string sentence = this.textDialogue[sentenceNumber];
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        this.sentenceNumber += 1;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueBox1.text = "";
        dialogueBox2.text = "";
        dialogueBox3.text = "";
        int selectedBox = 1;
        char[] charArray = sentence.ToCharArray();
        int newLine = 0;
        for (int i = 0; i < charArray.Length; i++)
        {
            switch (selectedBox)
            {
                case 1:
                    dialogueBox1.text += charArray[i];
                    break;
                case 2:
                    dialogueBox2.text += charArray[i];
                    break;
                case 3:
                    dialogueBox3.text += charArray[i];
                    break;
            }
            if (newLine / 50 >= 1)
            {
                if (i + 1 < charArray.Length)
                {
                    if (charArray[i + 1] == ' ')
                    {
                        selectedBox += 1;
                        i++;
                        newLine = 0;
                    }
                }
            }
            newLine++;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        animatorIsOpen = false;
        sentenceNumber = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearby = true;
            hintText.gameObject.SetActive(true);
            hintText.text = "Press 'E' to interact!";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearby = false;
            hintText.gameObject.SetActive(false);
        }
    }
}
}
