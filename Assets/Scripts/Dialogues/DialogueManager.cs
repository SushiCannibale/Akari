using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/* Singleton qui gère le dialogue courant avec quiconque.
 Le dialogue est récupéré par le DialogueTriggerer du gameobject à qui on parle. */
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    [SerializeField] private float waitWithinLetter;
    [SerializeField] private TMP_Text textBox;
    [SerializeField] private Animator dialogueBox;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
            throw new ApplicationException("Il y a plus d'un <DialogueManager>");
    }

    public Queue<string> Sentences { get; set; }
    private void Start() => Sentences = new Queue<string>();

    public void StartDialogue(Dialogue dialogue)
    {
        dialogue.IsActive = true;
        dialogueBox.SetTrigger("In");
        
        Sentences.Clear();
        foreach (string sentence in dialogue.GetLines()) 
            Sentences.Enqueue(sentence);
        
        NextSentence(dialogue);
    }

    public void NextSentence(Dialogue dialogue)
    {
        if (Sentences.Count == 0)
        {
            StopDialogue(dialogue);
            return;
        }
        
        StopAllCoroutines();
        StartCoroutine(TextAnimation(Sentences.Dequeue(), waitWithinLetter));
    }

    public void StopDialogue(Dialogue dialogue)
    {
        dialogue.IsActive = false;
        dialogueBox.SetTrigger("Out");
    }
    
    IEnumerator TextAnimation(string sentence, float waitInSec)
    {
        textBox.text = "";
        foreach (char c in sentence)
        {
            textBox.text += c;
            yield return new WaitForSeconds(waitInSec);
        }
    }
}
