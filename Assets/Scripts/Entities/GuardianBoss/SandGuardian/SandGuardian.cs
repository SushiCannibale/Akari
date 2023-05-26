using System;
using UnityEngine;

public class SandGuardian : AbstractGuardianBoss, IPersistentData
{
    [SerializeField] public Transform groundLevel;
    
    public void LoadFrom(GameData data)
    {
        Health = data.sandGuardianDead ? MaxHealth : 0f;
    }

    public void SaveTo(GameData data)
    {
        data.sandGuardianDead = Health > 0;
    }
}