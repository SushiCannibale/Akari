using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* State atteint lorsque le combat est lancé (trigger par le joueur) */
public class StoneGuardianAwakingState : StoneGuardianBaseState
{
    private Animator animator;
    private AnimatorStateInfo info;

    public override void Start(StoneGuardian guardian)
    {
        animator = guardian.Animator;
        animator.SetTrigger("Awake");
        info = animator.GetCurrentAnimatorStateInfo(0);
    }

    public override void Update(StoneGuardian guardian)
    {
        /* Ne pas toucher à cette atrocité, ça marche, c'est le principal... */
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime != info.normalizedTime && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) 
            guardian.ChangeState(guardian.IdleState);
    }

    public override void End(StoneGuardian guardian)
    {
        
    }
}
