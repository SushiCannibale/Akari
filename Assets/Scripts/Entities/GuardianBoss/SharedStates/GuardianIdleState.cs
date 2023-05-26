using UnityEngine;

public class GuardianIdleState : StateMachineBehaviour
{
    [SerializeField] private float timeBeforeNextAttack;
    [SerializeField] private float maxChaseDist;
    [SerializeField] private float minChaseDist;
    
    private AbstractGuardianBoss guardian;
    private float timer;
    private string nextAttack;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("ShockwaveOut"); 
        animator.ResetTrigger("SimpleAttack");
        // chaque state devrait se reset dans Exit() pour plus de clarté !
        
        guardian = animator.GetComponentInParent<AbstractGuardianBoss>();
        nextAttack = guardian.ChooseNextAttack();
        timer = timeBeforeNextAttack;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
        {
            animator.SetTrigger(nextAttack);
        }
        
        timer -= Time.deltaTime;
    }

    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform gTrans = guardian.transform;
        Vector3 gPos = gTrans.position;
        Vector3 pPos = guardian.Target.transform.position;
        Vector3 finalPos = new Vector3(pPos.x, gPos.y, pPos.z); // on garde la hauteur du guardian
        float dist = Vector3.Distance(gPos, pPos);

        if (dist <= minChaseDist || dist > maxChaseDist)
            return;
    
        gTrans.LookAt(finalPos);
        gTrans.Rotate(0f, 180.0f, 0f);

        guardian.transform.position = Vector3.Lerp(gPos, finalPos, dist / 6 * guardian.Speed * Time.deltaTime);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Idle");
    }
}