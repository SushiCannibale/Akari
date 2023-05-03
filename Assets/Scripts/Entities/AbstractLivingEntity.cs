using System;
using System.Collections;
using UnityEngine;

public abstract class AbstractLivingEntity : MonoBehaviour
{
    [SerializeField] protected float maxInvulnerableTime;
    [SerializeField] protected float blinkInterval;
    [SerializeField] protected int blinkTimes;
    
    public float MaxHealth { get; set; }
    public float Health { get; protected set; }
    public float Speed { get; protected set; }
    public float BaseDamage { get; protected set; }
    public bool IsAttacking { get; protected set; }
    public bool IsVulnerable { get; set; }
    
    public bool CanMove { get; set; }

    public void Initialize(float maxHealth, float speed, float baseDamage, bool vulnerable)
    {
        MaxHealth = maxHealth;
        Health = maxHealth;
        Speed = speed;
        BaseDamage = baseDamage;
        IsVulnerable = vulnerable;
        CanMove = true;
    }

    public bool IsAlive() => Health > 0;

    public void Hurt(float amount)
    {
        if (IsVulnerable)
        {
            // Jouer un son de dégât
            StartInvulnerability(maxInvulnerableTime, blinkInterval, blinkTimes);
            Health -= amount;
        }
        
        if (!IsAlive()) 
            Kill();
    }

    public abstract void Kill();

    IEnumerator HurtBlink(Renderer renderer, float blinkInterval, int blinkTimes)
    {
        for (int times = 0; times < blinkTimes; times++)
        {
            renderer.enabled = false;
            yield return new WaitForSeconds(blinkInterval);
            renderer.enabled = true;
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    IEnumerator TriggerInvulnerability(float seconds)
    {
        IsVulnerable = false;
        yield return new WaitForSeconds(seconds);
        IsVulnerable = true;
    }

    private void StartInvulnerability(float maxInvulnerableTime, float blinkInterval, int blinkTimes)
    {
        StartCoroutine(TriggerInvulnerability(maxInvulnerableTime));
        foreach (MeshRenderer rend in GetComponentsInChildren<MeshRenderer>())
            StartCoroutine(HurtBlink(rend, blinkInterval, blinkTimes));
    }
}