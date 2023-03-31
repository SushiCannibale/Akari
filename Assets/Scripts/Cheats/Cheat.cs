using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cheat : MonoBehaviour
{
    public bool IsActive { get; set; }
    public string Name { get; protected set; }
    public string DesacName { get; protected set; }
    public string ResponseText { get; protected set; }
    protected virtual void Awake()
    {
        // CheatCodeManager.PlayerCheatActivation += Activate;
        // CheatCodeManager.PlayerCheatDesactivation += Desactivate;
    }

    public virtual void Activate() => IsActive = true;

    public virtual void Desactivate() => IsActive = false;
}
