using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Singleton qui gère le dialogue courant avec quiconque.
 Le dialogue est récupéré par le DialogueTriggerer du gameobject à qui on parle. */
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
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
        Debug.Log("Dialogue commencé !");
        // Sentences.Clear();
        // foreach (string sentence in dialogue.GetLines()) 
        //     Sentences.Enqueue(sentence);
    }
    
    // public void StopDialogue() { }
}
