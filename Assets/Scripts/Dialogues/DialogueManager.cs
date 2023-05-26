using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/* Singleton qui gère le dialogue courant avec quiconque.
 Le dialogue est récupéré par le DialogueTriggerer du gameobject à qui on parle. */
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }
    
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Il y a déjà un DialogueManager dans la scène, il a été grand remplacé");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private float waitWithinLetter;
    
    [SerializeField] private Animator dialogueBox;
    // [SerializeField] private Animator buttonAnimator;
    
    [SerializeField] private TMP_Text textBox;
    // [SerializeField] private Image nextBtn;
    
    private float floating;
    public Queue<string> Sentences { get; set; }
    private string CurrentSentence { get; set; }
    
    private Dialogue CurrentDialogue { get; set; }
    
    public bool IsDialoguePlaying { get; private set; }
    public bool HasFinishedSentence { get; private set; }
    private Player Interactor { get; set; }

    private void Start() => Sentences = new Queue<string>();
    
    public void Trigger(Dialogue dialogue, Player interactor)
    {
        if (!IsDialoguePlaying) // commence le dialogue
        {
            CurrentDialogue = dialogue;
            Interactor = interactor;
            StartDialogue(dialogue);
        }
        else if (!HasFinishedSentence)
            ForceSentence();
        else
            NextSentence();
    }
    
    private void StartDialogue(Dialogue dialogue)
    {
        IsDialoguePlaying = true;
        Interactor.CanMove = false;
        
        dialogueBox.ResetTrigger("Out");
        dialogueBox.SetTrigger("In");
        
        Sentences.Clear();
        foreach (string sentence in dialogue.GetLines()) 
            Sentences.Enqueue(sentence);
        
        NextSentence();
    }
    
    private void NextSentence()
    {
        if (Sentences.Count == 0)
        {
            StopCurrentDialogue();
            return;
        }
        
        CurrentSentence = Sentences.Dequeue();
        
        StopAllCoroutines();

        HasFinishedSentence = false;
        
        StartCoroutine(TextAnimation(CurrentSentence, waitWithinLetter));
        StartCoroutine(Speech(CurrentDialogue.GetVoice(), CurrentDialogue.GetVoiceInterval()));
    }
    
    private void ForceSentence()
    {
        StopAllCoroutines();
        textBox.text = CurrentSentence;
        HasFinishedSentence = true;
        // buttonAnimator.SetTrigger("Appear");
    }
    
    public void StopCurrentDialogue()
    {
        IsDialoguePlaying = false;
        HasFinishedSentence = false;
        Interactor.CanMove = true;
        
        dialogueBox.ResetTrigger("In");
        dialogueBox.SetTrigger("Out");
        
        // buttonAnimator.ResetTrigger("Appear");
        // buttonAnimator.ResetTrigger("Clicked");
    }
    
    /* VFXs */
    
    // private void Update()
    // {
    //     if (HasFinishedSentence)
    //     {
    //         SetAlpha(nextBtn, Mathf.Sin(floating));
    //         floating = (floating + Time.deltaTime) % 360;
    //     }
    // }
    
    IEnumerator TextAnimation(string sentence, float waitInSec)
    {
        textBox.text = "";
        foreach (char c in sentence)
        {
            textBox.text += c;
            yield return new WaitForSeconds(waitInSec);
        }
    
        yield return null;
        HasFinishedSentence = true;
        // StartCoroutine(FloatAnimation(4f));
    }
    
    IEnumerator Speech(AudioSource voice, float interval)
    {
        while (!HasFinishedSentence)
        {
            voice.Play();
            yield return new WaitForSeconds(interval);
        }
    }
    
    // IEnumerator FloatAnimation(float speed)
    // {
    //     float s = 0f;
    //     while (HasFinishedSentence)
    //     {
    //         SetAlpha(nextBtn, Mathf.Sin(s) + 0.5f);
    //         s += Time.deltaTime * speed;
    //         yield return null;
    //     }
    // }
    
    // private void SetAlpha(Image image, float alpha)
    // {
    //     Color c = image.color;
    //     c.a = alpha;
    //     image.color = c;
    // }
}
