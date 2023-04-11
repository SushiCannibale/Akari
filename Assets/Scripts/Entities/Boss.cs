using System;
using UnityEngine;

public abstract class Boss : LivingEntity
{
    protected bool hasFightStarted;
    private HealthBar healthBar;
    public Player target;
    public override void Initialize(float maxHealth, float speed, float baseDamage)
    {
        base.Initialize(maxHealth, speed, baseDamage);
        hasFightStarted = false;
    }

    public virtual void StartFight(Player player)
    {
        target = player;
        hasFightStarted = true;
    }

    // public Player RenewTarget()
    // {
    //     // TODO
    // }
}