using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CheatCode : MonoBehaviour
{
    private void Awake()
    {
        EventManager.PlayerCheatEvent += Activate;
    }

    public string Name { get; private set; }
    public string ResponseText { get; private set; }

    public abstract void Activate();
}
