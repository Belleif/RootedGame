using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDialogue : MonoBehaviour
{
    public bool playerActive = false;
    public Animator charAnim;
    public DialogueUI dialogueUI;
    public DialogueObject testDialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (playerActive == false)
            {
                charAnim.SetBool("IsRunning", false);
                dialogueUI.ShowDialogue(testDialogue);
                playerActive = true;
            }
        }
    }
}
