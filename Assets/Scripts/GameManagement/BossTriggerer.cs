using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BossTriggerer : MonoBehaviour, IBossFightTriggerer
{
    [SerializeField] private AbstractGuardianBoss boss;

    public void TriggerBossFight(Player player)
    {
        if (boss.IsAlive())
            boss.StartFight(player);
        Destroy(gameObject);
    }
}