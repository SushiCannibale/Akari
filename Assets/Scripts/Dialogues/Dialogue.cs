using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

[Serializable]
public class Dialogue
{
    /* Une string = Une boîte de texte */
    [TextArea(3, 10)] [SerializeField] private List<string> Lines;
    [SerializeField] [CanBeNull] private AudioSource Voice;
    [SerializeField] private float VoiceInterval;
    public List<string> GetLines() => Lines;

    [CanBeNull] public AudioSource GetVoice() => Voice;
    public float GetVoiceInterval() => VoiceInterval;

}