﻿using System;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    private void Awake() => DontDestroyOnLoad(this);
}