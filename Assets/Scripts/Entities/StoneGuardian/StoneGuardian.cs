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
    private Animator animator;

    // Nombre de fois que le mob va devenir transparent lorsqu'il est frappé
    [SerializeField] private int blinkTimes;
    
    // Intervalle entre les différents transparences du mob
    [SerializeField] private float blinkInterval;
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

    // private void Update()
    // {
    //     
    // }

    public void Hurt(float amount)
    {
        if (IsVulnerable)
        {
            // Jouer un son de dégât
            StartCoroutine(TriggerInvulnerability(maxInvulnerableTime));
            foreach (Renderer rend in GetComponentsInChildren<MeshRenderer>())
                StartCoroutine(HurtBlink(rend, blinkInterval, blinkTimes));
            Health -= amount;
        }
        
        if (Health <= 0)
            Kill();
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
    
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
}
