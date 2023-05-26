using System;
using UnityEngine;

public class SandPillar : MonoBehaviour, IDamageProvider
{
    [SerializeField] private Animator animator;
    [SerializeField] private float maxWarnTime;
    [SerializeField] private float warnSpeed;
    [SerializeField] private SandWarnSprite sandWarn;
    
    private float timer;

    public void SummonAt(Vector3 pos)
    {
        transform.position = pos;
        timer = 0f;
        Instantiate(sandWarn).SummonAt(pos, new Vector3(warnSpeed, warnSpeed, 0));
    }

    private void Update()
    {
        if (timer >= maxWarnTime)
        {
            animator.SetBool("Show", true);
            enabled = false;
        }

        timer += Time.deltaTime;
    }

    public bool IsLethal() => true;
    public float DamageAmount() => 1f;
    // pas mettre en dur !
}