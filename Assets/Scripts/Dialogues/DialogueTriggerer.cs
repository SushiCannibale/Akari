using System;
using UnityEngine;

/* Script qui se charge d'envoyer le dialogue du PNJ au DialogueManager */
public class DialogueTriggerer : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    public void TriggerDialogue()
    {
        if (!dialogue.HasStarted)
            DialogueManager.Instance.StartDialogue(dialogue);
        else
            DialogueManager.Instance.NextSentence(dialogue);
    }
}