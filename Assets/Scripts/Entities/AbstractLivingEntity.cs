using System;
using System.Collections;
using UnityEngine;

public abstract class AbstractLivingEntity : MonoBehaviour
{
    [SerializeField] protected EntityData data;
    [SerializeField] protected AudioSource HurtSound;
    
    public float MaxHealth => data.maxHealth;
    public float MaxInvulnerableTime => data.maxInvulnerableTime;
    public float Speed => data.speed;
    public float BaseDamage => data.baseDamage;
    public float BlinkInterval => data.blinkInterval;
    public int BlinkTimes => data.blinkTimes;
    
    public float Health { get; protected set; }
    public bool IsAttacking { get; set; }
    public bool IsVulnerable { get; set; }
    public bool CanMove { get; set; }

    public void Initialize(bool vulnerable)
    {
        Health = MaxHealth;
        IsAttacking = false;
        IsVulnerable = vulnerable;
        CanMove = true;
    }

    public bool IsAlive() => Health > 0;

    public void Hurt(float amount)
    {
        if (IsAlive() && IsVulnerable)
        {
            StartInvulnerability(MaxInvulnerableTime, BlinkInterval, BlinkTimes);
            Health -= amount;
            HurtSound.Play();
            
            if (Health - amount <= 0)
            {
                Kill();   
            }
        }
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