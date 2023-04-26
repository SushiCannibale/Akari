using System;
using UnityEngine;

/* Script qui se charge d'envoyer le dialogue du PNJ au DialogueManager */
[RequireComponent(typeof(AbstractEntityDialogue))]
public class DialogueTriggerer : MonoBehaviour
{
    private Dialogue dialogue;
    private void Awake() => dialogue = GetComponent<Dialogue>();

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (Input.GetKeyDown(GameUtils.Keys.INTERACT))
        {
            DialogueManager.Instance.StartDialogue(dialogue);
        }
    }
}