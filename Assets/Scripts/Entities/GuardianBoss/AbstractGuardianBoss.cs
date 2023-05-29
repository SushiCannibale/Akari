using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGuardianBoss : AbstractLivingEntity
{
    [SerializeField] protected Animator animator;
    [SerializeField] public GuardianArm leftArm;
    [SerializeField] public GuardianArm rightArm;

    [SerializeField] private AudioSource emergeSound;

    [SerializeField] protected List<string> attacks;
    [SerializeField] protected List<GameObject> relatedCorruption;

    private int debgAttkIndex;
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
        debgAttkIndex = 0;
    }

    public override void Kill()
    {
        base.Kill();
        animator.SetTrigger("Death");
        IsVulnerable = false;
        GameManager.Instance.SaveData();
        relatedCorruption.ForEach(obj => Destroy(obj));
        // StartCoroutine(FadeCorruption());
    }

    // IEnumerator FadeCorruption()
    // {
    //     float alpha = 1f;
    //     while (alpha > 0)
    //     {
    //         alpha -= Time.deltaTime;
    //         relatedCorruption.ForEach(obj =>
    //         {
    //             foreach (var renderer in obj.GetComponentsInChildren<Renderer>())
    //             {
    //                 Color color = renderer.material.color;
    //                 renderer.material.color = new Color(color.r, color.g, color.b, alpha);
    //             }
    //                 
    //         });
    //         yield return null;
    //     }
    //     
    //     relatedCorruption.ForEach(obj => Destroy(obj));
    // }

    public string ChooseNextAttack()
    {
        string s = attacks[debgAttkIndex];
        debgAttkIndex = (debgAttkIndex + 1) % attacks.Count;
        return s;
    }
    
    // public string ChooseNextAttack()
    // {
    //     return attacks[Random.Range(0, attacks.Count)];
    // }

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