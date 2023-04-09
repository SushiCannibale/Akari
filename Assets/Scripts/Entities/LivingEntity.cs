using System;
using UnityEngine;

public abstract class LivingEntity : MonoBehaviour
{
    protected Transform Position;
    
    public float MaxHealth { get; }
    public float Health { get; protected set; }
    public float Speed { get; protected set; }
    public float BaseDamage { get; protected set; }

    private void Awake()
    {
        Position = GetComponent<Transform>();
    }

    public bool IsAlive() => Health > 0;

    public abstract void Attack(LivingEntity livingEntity);

    public void Hurt(float amount) => Health -= amount;

    protected abstract void Update();
}