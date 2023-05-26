using System;
using UnityEngine;

public class GuardianArm : MonoBehaviour, IDamageProvider
{
    [SerializeField] private AbstractGuardianBoss guardian;
    [SerializeField] public Transform ShockwavePosition;

    // private void Start()
    // {
    //     transform.position = ShockwavePosition.position;
    // }

    public bool IsLethal() => guardian.IsAttacking;
    public float DamageAmount() => guardian.BaseDamage;
}