using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* State de "transition". Comme le Var. on y passe mais on y reste jamais.
 Atteint après une attaque / l'awake 
 Sers juste à pauser le combat un moment avant de passer au state suivant. */
public class StoneGuardianIdleState : StoneGuardianBaseState
{
    private float timeElasped;
    private float timeBeforeChange;
    private float minTime;
    private float maxTime;

    public StoneGuardianIdleState(float minRngTime, float maxRngTime)
    {
        minTime = minRngTime;
        maxTime = maxRngTime;
    }
    
    public override void Start(StoneGuardian guardian)
    {
        timeElasped = 0f;
        timeBeforeChange = Random.Range(minTime, maxTime);
        guardian.Animator.SetTrigger("Idle");
    }

    public override void Update(StoneGuardian guardian)
    {
        if (timeElasped >= timeBeforeChange)
            guardian.ChangeState(guardian.AttackingState);

        timeElasped += Time.deltaTime;
    }

    public override void End(StoneGuardian guardian)
    {
        
    }
}
