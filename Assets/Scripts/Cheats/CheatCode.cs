using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CheatCode : MonoBehaviour
{
    private void Awake()
    {
        EventManager.ActivePlayerCheatEvents += Activate;
    }

    public string Name { get; protected set; }
    public string ResponseText { get; protected set; }

    public abstract void Activate();
}
