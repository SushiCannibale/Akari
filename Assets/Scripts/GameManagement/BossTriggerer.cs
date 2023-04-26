using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BossTriggerer : MonoBehaviour
{
    [SerializeField] private AbstractBoss boss;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            boss.StartFight(player);
            Destroy(gameObject);
        }
    }
}