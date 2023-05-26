using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class AbstractGuardianBoss : AbstractLivingEntity
{
    [SerializeField] protected Animator animator;
    [SerializeField] public GuardianArm leftArm;
    [SerializeField] public GuardianArm rightArm;

    [SerializeField] private AudioSource emergeSound;

    [SerializeField] protected List<string> attacks;
    public Player Target { get; protected set; }

    private void Awake()
    {
        Initialize(false);
    }

    public void StartFight(Player player)
    {
        emergeSound.Play();
        Target = player;
        animator.SetTrigger("Awake");
    }

    public override void Kill()
    {
        base.Kill();
        animator.SetTrigger("Death");
        IsVulnerable = false;
        GameManager.Instance.SaveData();
        // GameManager.Instance.Annihilate(go => go.CompareTag("Corruption"));
    }
    
    public string ChooseNextAttack()
    {
        return attacks[Random.Range(0, attacks.Count)];
    }

    // public Player FindNearestPlayer(float minDist, float maxDist)
    // {
    //     Player[] players = FindObjectsOfType<Player>().OrderBy(
    //         p => Vector3.Distance(p.transform.position, transform.position)).ToArray();
    //
    //     if (players.Length == 0)
    //         throw new NullReferenceException("There is no player in the game !");
    //     return players[0];
    // }
}