using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Dialogue
{
    /* Une string = Une boîte de texte */
    private List<string> Lines;
    public List<string> GetLines() => Lines;
}