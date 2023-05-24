using System;
using UnityEngine;

/* Script qui se charge d'envoyer le dialogue du PNJ au DialogueManager */
public class DialogueTriggerer : MonoBehaviour, IInteractible
{
    public Dialogue Dialogue;
    // public void TriggerDialogue() => DialogueManager.Instance.TriggerDialogue(Dialogue);
    // public void StopDialogue() => DialogueManager.Instance.StopCurrentDialogue();
    public void Interact(Player interactor)
    {
        DialogueManager.Instance.Trigger(Dialogue, interactor);
    }
}