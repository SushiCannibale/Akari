using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StoneGuardian : Boss
{
    /* Liste des noms des attaques dans l'animator */
    [SerializeField] private float speed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float damage;
    
    [SerializeField] private List<string> attacks;
    private Animator animator;

    public bool IsVulnerable;
    public float maxInvulnerableTime;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        IsVulnerable = false;
        Initialize(maxHealth, speed, damage);
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
        if (IsVulnerable)
        {
            StartCoroutine(TriggerInvulnerability(maxInvulnerableTime));
            Health -= amount;
        }
    }

    IEnumerator TriggerInvulnerability(float seconds)
    {
        float time = 0;
        IsVulnerable = false;

        while (time < seconds)
        {
            time += Time.deltaTime;
            yield return -1;
        }

        IsVulnerable = true;
    }
}
