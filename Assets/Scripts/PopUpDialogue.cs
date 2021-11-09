using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDialogue : MonoBehaviour
{
    public bool playerActive = false;
    public GameObject dialogueActiveGUI;
    public GameObject triggerActiveGUI;
    public DialogueUI dialogueUI;
    public DialogueObject testDialogue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerActive && Input.GetKeyDown("e"))
        {
            Debug.Log("Key Pressed");
            triggerActiveGUI.SetActive(false);
            dialogueUI.ShowDialogue(testDialogue);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerActiveGUI.SetActive(true);
            playerActive = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggerActiveGUI.SetActive(false);
            dialogueActiveGUI.SetActive(false);
            playerActive = false;
        }
    }
}
