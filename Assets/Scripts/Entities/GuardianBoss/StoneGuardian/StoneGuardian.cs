using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StoneGuardian : AbstractGuardianBoss, IPersistentData
{
    public void LoadFrom(GameData data)
    {
        Health = data.stoneGuardianDead ? MaxHealth : 0f;
    }

    public void SaveTo(GameData data)
    {
        data.stoneGuardianDead = !IsAlive();
    }
}
