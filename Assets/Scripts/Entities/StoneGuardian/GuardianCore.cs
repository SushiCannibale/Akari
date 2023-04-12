using UnityEngine;

public class GuardianCore : MonoBehaviour, IDamageable
{
    private StoneGuardian guardian;
    public bool Vulnerable { get; private set; }

    private void Awake()
    {
        guardian = GetComponentInParent<StoneGuardian>();
        Vulnerable = false;
    }

    public void Hurt(float amount)
    {
        guardian.Hurt(amount);
    }
}