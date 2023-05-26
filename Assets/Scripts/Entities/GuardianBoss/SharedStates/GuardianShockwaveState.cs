using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GuardianShockwaveState : GuardianAttackState
{
    [SerializeField] private ShockwaveSprite shockwave;
    [SerializeField] private float maxVulnerableTime;
    private bool hasShocked;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        hasShocked = false;
        guardian.IsVulnerable = true;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer >= maxVulnerableTime)
        {
            animator.SetTrigger("ShockwaveOut");
        }
        
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (!hasShocked && stateInfo.normalizedTime >= 0.9f)
        {
            hasShocked = true;
            
            Instantiate(shockwave).transform.position = guardian.leftArm.ShockwavePosition.position;
            Instantiate(shockwave).transform.position = guardian.rightArm.ShockwavePosition.position;
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateExit(animator, stateInfo, layerIndex);

        guardian.IsVulnerable = false;
        animator.ResetTrigger("ShockwaveIn");
    }
}
