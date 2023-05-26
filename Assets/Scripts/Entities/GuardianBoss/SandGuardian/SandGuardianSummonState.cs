using UnityEngine;

public class SandGuardianSummonState : StateMachineBehaviour
{
    [SerializeField] private float maxTimeSummoning;
    [SerializeField] private float summonInterval;
    [SerializeField] private SandPillar pillar;
    
    private SandGuardian guardian;
    private float summonTimer;
    private float timer;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        guardian = animator.gameObject.GetComponentInParent<SandGuardian>();
        summonTimer = 0f;
        timer = 0f;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 pPos = guardian.Target.transform.position;
        if (summonTimer >= summonInterval)
        {
            summonTimer = 0f;
            Instantiate(pillar).SummonAt(new Vector3(pPos.x, guardian.groundLevel.position.y, pPos.z));
        }

        if (timer >= maxTimeSummoning)
        {
            animator.SetTrigger("SummonOut");
        }

        summonTimer += Time.deltaTime;
        timer += Time.deltaTime;
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("SummonIn");
        animator.ResetTrigger("SummonOut");
        // évite de le mettre en dur !!
    }
}