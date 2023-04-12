using System;
using UnityEngine;

public class BossStoneGuardian : Boss
{
    // private Animator animator;
    // private GuardianBossCore bossCore;
    //
    // private Transform leftFist;
    // private Transform rightFist;
    //
    // public float attackSpeed;
    // public bool isAttacking;
    // private void Awake()
    // {
    //     animator = GetComponent<Animator>();
    //     bossCore = GetComponentInChildren<GuardianBossCore>();
    //
    //     leftFist = transform.GetChild(2);
    //     rightFist = transform.GetChild(3);
    //     
    //     Initialize(100.0f, 4.0f, 10.0f);
    // }
    //
    // public override void StartFight(Player player)
    // {
    //     base.StartFight(player);
    //     animator.SetTrigger("Awake");
    // }
    //
    // public void ApplyCoreDamages(float amount)
    // {
    //     Health -= amount;
    //     animator.SetTrigger("Hit");
    // }
    //
    // // Called after Animator
    // private void FixedUpdate()
    // {
    //     if (!isAttacking)
    //         return;
    //     
    //     // Iic, l'animation Attack_Start est finie => animator désactivé sinon problèmes >:[
    //     
    //     FistUpdate(leftFist);
    //     FistUpdate(rightFist);
    // }
    //
    // private void FistUpdate(Transform part)
    // {
    //     Vector3 targetDir = target.transform.position - part.position;
    //     targetDir.Normalize();
    //
    //     part.position += targetDir * attackSpeed * Time.deltaTime;
    //     // Debug.DrawLine(leftFist.position, leftFist.position + Vector3.right, Color.red);
    //     Vector3 targetPos = target.transform.position;
    //     Vector3 axis = new Vector3(targetPos.x + targetPos.z, 0, targetPos.x + targetPos.z);
    //     
    //     // Debug.DrawLine(leftFist.position, leftFist.position - axis, Color.red);
    //     
    //     part.LookAt(targetPos);
    //     part.Rotate(-axis, 90.0f);
    // }
    public override void StartFight(Player player)
    {
        throw new NotImplementedException();
    }
}