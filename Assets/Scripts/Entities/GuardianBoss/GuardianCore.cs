using System;
using System.Collections;
using UnityEngine;

public class GuardianCore : MonoBehaviour, IDamageable
{
    private AbstractGuardianBoss guardian;
    private void Awake() => guardian = GetComponentInParent<AbstractGuardianBoss>();
    public void Hurt(float amount)
    {
        if (guardian.IsVulnerable)
            guardian.Hurt(amount);
    }
}