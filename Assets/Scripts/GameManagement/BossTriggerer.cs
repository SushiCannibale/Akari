using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BossTriggerer : MonoBehaviour, IBossFightTriggerer
{
    [SerializeField] private AbstractGuardianBoss boss;

    public void TriggerBossFight(Player player)
    {
        boss.StartFight(player);
        Destroy(gameObject);
    }
}