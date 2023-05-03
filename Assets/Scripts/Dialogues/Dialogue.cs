using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Dialogue
{
    /* Une string = Une boîte de texte */
    [TextArea(3, 10)]
    [SerializeField] private List<string> Lines;
    public List<string> GetLines() => Lines;
    
    public bool IsActive { get; set; }
    
    public AudioSource Voice { get; set; }
}