using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianShockwaveState : StateMachineBehaviour
{
    [SerializeField] private string shockwaveOut;
    [SerializeField] private float maxTimeVulnerable;
    private float time;

    private StoneGuardian guardian;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        guardian = animator.GetComponent<StoneGuardian>();
        guardian.IsVulnerable = true;
        time = 0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(time);
        if (time >= maxTimeVulnerable)
        {
            guardian.IsVulnerable = false;
            animator.SetTrigger(shockwaveOut);
            return;
        }
        time += Time.deltaTime;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
