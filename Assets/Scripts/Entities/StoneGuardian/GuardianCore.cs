using System;
using System.Collections;
using UnityEngine;

public class GuardianCore : MonoBehaviour, IDamageable
{
    private StoneGuardian guardian;

    private void Awake()
    {
        guardian = GetComponentInParent<StoneGuardian>();
    }

    public void Hurt(float amount)
    {
        guardian.Hurt(amount);
    }

    public void Kill()
    {
        guardian.Kill();
    }
}