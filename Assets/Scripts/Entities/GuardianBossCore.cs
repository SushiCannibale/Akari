using UnityEngine;

public class GuardianBossCore : MonoBehaviour, IDamageable
{
    private float angle = 0f;
    private BossStoneGuardian guardian;
    private bool isInvincible;

    private void Awake()
    {
        guardian = GetComponentInParent<BossStoneGuardian>();
        isInvincible = true;
    }

    private void Update()
    {
        if (!guardian.IsAlive())
            return;
        
        transform.Rotate(angle, angle, angle);
    }

    public void Hurt(float amount)
    {
        guardian.ApplyCoreDamages(amount);
    }
}