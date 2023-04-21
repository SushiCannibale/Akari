using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Le concept est que lorsque l'on trigger le dialogue avec un PNJ,
 celui-ci remplisse la Queue<> avec les dialogues présents dans sa classe */
public class DialogueManager : MonoBehaviour
{
    public Queue<string> Sentences { get; set; }
    private void Start() => Sentences = new Queue<string>();

    public void StartDialogue(Dialogue dialogue)
    {
        Sentences.Clear();
        foreach (string sentence in dialogue.GetLines()) 
            Sentences.Enqueue(sentence);
        
        
    }
    
    public void StopDialogue() { }
}
