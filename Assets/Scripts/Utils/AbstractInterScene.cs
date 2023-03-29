using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractInterScene : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
