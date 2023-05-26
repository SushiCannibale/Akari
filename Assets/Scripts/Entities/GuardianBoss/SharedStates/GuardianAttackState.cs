using UnityEngine;

public class GuardianAttackState : StateMachineBehaviour
{
    protected AbstractGuardianBoss guardian;
    protected float timer;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;
        guardian = animator.GetComponentInParent<AbstractGuardianBoss>();
        guardian.IsAttacking = true;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        guardian.IsAttacking = false;
    }
}