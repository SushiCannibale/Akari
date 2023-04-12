using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 State atteint lorsque le guardian lance son attaque.
 Il se termine lorsque :
 - Le joueur a été hit par un des bras
 - Les deux bras ont touché un mur (-> Passe au <VulnerableState>)
 - Le temps max à été dépassé. 
 */
public class StoneGuardianAttackingState : StoneGuardianBaseState
{
    private AnimatorStateInfo info;
    private float timeElapsed;
    private float maxAttackTime;

    private StoneGuardianArm leftArm;
    private StoneGuardianArm rightArm;

    public StoneGuardianAttackingState(float maxTime)
    {
        maxAttackTime = maxTime;
    }
    
    public override void Start(StoneGuardian guardian)
    {
        info = guardian.Animator.GetCurrentAnimatorStateInfo(0);
        guardian.Animator.SetTrigger("AttackStart");
        timeElapsed = 0f;

        leftArm = guardian.transform.GetChild(2).gameObject.GetComponent<StoneGuardianArm>();
        rightArm = guardian.transform.GetChild(3).gameObject.GetComponent<StoneGuardianArm>();
        
        leftArm.enabled = true;
        rightArm.enabled = true;
    }

    public override void Update(StoneGuardian guardian)
    {
        if (guardian.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime != info.normalizedTime &&
            guardian.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            guardian.Animator.enabled = false;
        }

        if (guardian.Animator.enabled)
            return;

        Attack(guardian, leftArm.transform);
        Attack(guardian, rightArm.transform);

        if (ShouldBeVulnerable())
        {
            Debug.Log("Vulnerable !");
            guardian.ChangeState(guardian.VulnerableState);
        }

        if (HitPlayer())
        {
            Debug.Log("Hit player !");
            guardian.ChangeState(guardian.IdleState);
        }
    }

    private void Attack(StoneGuardian guardian, Transform part)
    {
        Vector3 targetPos = guardian.Target.transform.position;
        Vector3 targetDir = targetPos - part.position;
        targetDir.Normalize();
        
        Vector3 axis = new Vector3(targetPos.x + targetPos.z, 0, targetPos.x + targetPos.z);
        
        part.position += targetDir * Time.deltaTime;
        
        part.LookAt(targetPos);
        part.Rotate(-axis, 90.0f);
    }

    private bool ShouldBeVulnerable()
    {
        return leftArm.CollideWithWall && rightArm.CollideWithWall;
    }

    private bool HitPlayer()
    {
        return leftArm.CollideWithPlayer && rightArm.CollideWithPlayer;
    }

    public override void End(StoneGuardian guardian)
    {
        Reset(leftArm);
        Reset(rightArm);
        /* Réactive l'animator */
        guardian.Animator.enabled = true;
    }

    private void Reset(StoneGuardianArm part)
    {
        part.transform.position = new Vector3(0, 0, 0);
        part.transform.rotation = Quaternion.identity;
        // part.enabled = false;
    }
}
