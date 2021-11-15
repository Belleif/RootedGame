using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueUI : MonoBehaviour
{
    public PopUpDialogue popUpDialogue;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;

    private TypewriterEffect typewriterEffect;

    private void Start()
    {
        typewriterEffect = GetComponent<TypewriterEffect>();
        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
      foreach (string dialogue in dialogueObject.Dialogue)
       {
           // if (popUpDialogue.playerActive == true)
           // {
                yield return typewriterEffect.Run(dialogue, textLabel);
                yield return new WaitForSeconds(2);
           // }
           // else
           // {
           //     break;
            //}
        //yield return new WaitUntil(() => Input.GetKeyDown("e"));
       }
        CloseDialogueBox();
        
    }

    public void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
