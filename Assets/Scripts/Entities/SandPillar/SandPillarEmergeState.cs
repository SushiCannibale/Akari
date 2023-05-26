using UnityEngine;

public class SandPillarEmergeState : StateMachineBehaviour
{
    [SerializeField] private float maxTimeShown;

    private float timer;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer >= maxTimeShown)
        {
            animator.SetBool("Show", false);
        }

        timer += Time.deltaTime;
    }
}