using System;
using System.Collections;
using UnityEngine;

public abstract class LivingEntity : MonoBehaviour
{
    public float MaxHealth { get; set; }
    public float Health { get; protected set; }
    public float Speed { get; protected set; }
    public float BaseDamage { get; protected set; }

    public void Initialize(float maxHealth, float speed, float baseDamage)
    {
        MaxHealth = maxHealth;
        Health = maxHealth;
        Speed = speed;
        BaseDamage = baseDamage;
    }

    public bool IsAlive() => Health > 0;

    // public IEnumerator SwitchColor(MeshRenderer[] renderers, Color color, float seconds)
    // {
    //     Color[] defaults = new Color[renderers.Length];
    //     for (int i = 0; i < renderers.Length; i++)
    //     {
    //         defaults[i] = renderers[i].material.color;
    //         renderers[i].material.color = color;
    //     }
    //         
    //     yield return new WaitForSeconds(seconds);
    //     
    //     for (int i = 0; i < renderers.Length; i++)
    //         renderers[i].material.color = defaults[i];
    // }
}