using System;
using UnityEngine;

public class SandGuardian : AbstractGuardianBoss, IPersistentData
{
    [SerializeField] public Transform groundLevel;
    
    public void LoadFrom(GameData data)
    {
        Health = data.sandGuardianData.isDead ? 0f : MaxHealth;
        transform.position = data.sandGuardianData.position;
        
        if (data.sandGuardianData.isDead)
        {
            animator.SetTrigger("Death");
            relatedCorruption.ForEach(obj => Destroy(obj));
        }
    }

    public void SaveTo(GameData data)
    {
        data.sandGuardianData.position = transform.position;
        data.sandGuardianData.isDead = !IsAlive();
    }
}