using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StoneGuardian : AbstractBoss
{
    /* Liste des noms des attaques dans l'animator */
    [SerializeField] private float speed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float damage;
    
    // Noms des attaques de l'animator que le mob peut utiliser
    [SerializeField] private List<string> attacks;
    [SerializeField] private string deathTrigger;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        IsVulnerable = false;
        Initialize(maxHealth, speed, damage, false);
    }

    public override void StartFight(Player player)
    {
        Target = player;
        animator.SetTrigger("Awake");
    }

    public string ChooseNextAttack()
    {
        int i = Mathf.RoundToInt(Random.Range(0f, 100f) / 100f);
        return attacks[i];
    }

    public void ActivateDamageCollider(bool f) => IsAttacking = f;

    public override void Kill() => animator.SetTrigger(deathTrigger);
}
