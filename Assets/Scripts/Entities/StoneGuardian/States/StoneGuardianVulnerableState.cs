using UnityEngine;

/*
 State atteint après <StoneGuardianAttackingState>
 lorsque les bras ont touchés un mur et sont bloqués. 
 */
public class StoneGuardianVulnerableState : StoneGuardianBaseState
{
    /* Temps écoulé depuis le début de la phase d'invincibilité */
    private float timeElapsed;

    /* Temps maximum de la phase d'invincibilité (en secondes) */
    private float maxTime;
    /* Dégats maximum de la phase d'invincibilité */
    private float maxDamage;

    public StoneGuardianVulnerableState(float maxTimeInvincibleInSec, float maxDamageInvincible)
    {
        maxTime = maxTimeInvincibleInSec;
        maxDamage = maxDamageInvincible;
    }
    
    public override void Start(StoneGuardian guardian)
    {
        timeElapsed = 0f;
    }

    public override void Update(StoneGuardian guardian)
    {
        if (timeElapsed >= maxTime || guardian.Health <= guardian.Health - maxDamage)
        {
            // guardian.ChangeState(guardian.IdleState);
            // Retreive les bras
        }

        timeElapsed += Time.deltaTime;
    }

    public override void End(StoneGuardian guardian)
    {
        throw new System.NotImplementedException();
    }
}