using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class StoneGuardianAttack : StateMachineBehaviour
{
    private float timer;
    public float minTimer;
    public float maxTimer;

    private BossStoneGuardian boss;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(minTimer, maxTimer);
        boss = animator.gameObject.GetComponent<BossStoneGuardian>();
        
        // rightFist = animator.transform.GetChild(3).gameObject;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime < 0.8f)
            return;

        boss.isAttacking = true;

        if (stateInfo.normalizedTime >= 1.0f)
            animator.enabled = false;
        
        /* Ici, l'animation a fini de se jouer a 80% */
        // Debug.Log(leftFistHolder.name);
        //
        // Vector3 targetPos = boss.target.transform.position;
        //
        // Vector3 targetDir = targetPos - leftFistHolder.position;
        // targetDir.Normalize();
        //
        // Vector3 rotatedDir = Vector3.RotateTowards(leftFistHolder.forward, targetDir, 1000 * Time.deltaTime, 0.0F);
        //
        // leftFistHolder.position += targetDir * Time.deltaTime;
        // leftFistHolder.rotation = Quaternion.LookRotation(-rotatedDir);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.isAttacking = false;
    }
}
