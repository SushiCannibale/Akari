using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianIdleState : StateMachineBehaviour
{
    [SerializeField] private float minRng;
    [SerializeField] private float maxRng;
    [SerializeField] private float maxWait;
    
    private float time;
    private StoneGuardian guardian;

    private bool shouldAttack;
    [SerializeField] private float minAttackDist;
    [SerializeField] private float maxAttackDist;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        guardian = animator.GetComponentInParent<StoneGuardian>();
        time = Random.Range(minRng, maxRng);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float dist = Vector3.Distance(guardian.transform.position, guardian.Target.transform.position);
        shouldAttack = dist >= minAttackDist && dist <= maxAttackDist;
        
        if (time >= maxWait && shouldAttack)
        {
            animator.SetTrigger(guardian.ChooseNextAttack());
            return;
            
        }
        time += Time.deltaTime;

    }

    /* Probablement le saint graal, et je déconne même pô :O */
    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform gTrans = guardian.transform;
        Vector3 gPos = gTrans.position;
        Vector3 pPos = guardian.Target.transform.position;
        Vector3 finalPos = new Vector3(pPos.x, gPos.y, pPos.z); // on garde la hauteur du guardian !

        gTrans.LookAt(finalPos);
        gTrans.Rotate(0f, 180.0f, 0f);
        
        if (shouldAttack)
        {
            return;
        }
        
        guardian.transform.position = Vector3.Lerp(gPos, finalPos, Vector3.Distance(gPos, pPos) / 6 * guardian.Speed * Time.deltaTime);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
