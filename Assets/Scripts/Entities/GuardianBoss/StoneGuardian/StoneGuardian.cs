using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StoneGuardian : AbstractGuardianBoss, IPersistentData
{
    public void LoadFrom(GameData data)
    {
        Health = data.stoneGuardianData.isDead ? 0f : MaxHealth;
        transform.position = data.stoneGuardianData.position;

        if (data.stoneGuardianData.isDead)
        {
            animator.SetTrigger("Death");
            relatedCorruption.ForEach(obj => Destroy(obj));
        }
            
    }

    public void SaveTo(GameData data)
    {
        data.stoneGuardianData.position = transform.position;
        data.stoneGuardianData.isDead = !IsAlive();
    }
}
