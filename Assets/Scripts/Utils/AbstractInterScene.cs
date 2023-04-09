using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInterScene : MonoBehaviour
{
    protected virtual void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
