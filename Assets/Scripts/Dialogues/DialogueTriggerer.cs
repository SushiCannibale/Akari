using System;
using UnityEngine;

/* Script qui se charge d'envoyer le dialogue du PNJ au DialogueManager */
public class DialogueTriggerer : MonoBehaviour
{
    public Dialogue Dialogue;
    [SerializeField] private AudioSource voice;

    private void Awake() => voice = GetComponent<AudioSource>();

    public void TriggerDialogue()
    {
        Dialogue.Voice = voice;
        if (!Dialogue.IsActive)
            DialogueManager.Instance.StartDialogue(Dialogue);
        else
            DialogueManager.Instance.NextSentence(Dialogue);
    }

    public void StopDialogue() => DialogueManager.Instance.StopDialogue(Dialogue);
}