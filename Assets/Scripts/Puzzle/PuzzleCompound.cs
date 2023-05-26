using System;
using UnityEngine;

public abstract class PuzzleCompound : MonoBehaviour
{
    public bool IsActive { get; set; }
    public abstract void Action();
    private void Update()
    {
        if (!IsActive)
            return;
        
        Action();
    }
}