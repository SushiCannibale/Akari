using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StoneGuardian : Boss
{
    /* Liste des noms des attaques dans l'animator */
    [SerializeField] private List<string> attacks;
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        Initialize(100.0f, 5.0f, 2.0f);
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

    public void Hurt(float amount)
    {
        Health -= amount;
    }
}
