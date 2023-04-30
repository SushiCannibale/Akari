using System;
using System.Linq;
using UnityEngine;

public abstract class AbstractBoss : AbstractLivingEntity
{
    public Player Target { get; protected set; }

    /* Appelée par ce qui va lancer le combat (cf. AbstractBossTriggerer.cs) */
    public abstract void StartFight(Player player);

    public Player FindNearestPlayer(float minDist, float maxDist)
    {
        Player[] players = FindObjectsOfType<Player>().OrderBy(
            p => Vector3.Distance(p.transform.position, transform.position)).ToArray();

        if (players.Length == 0)
            throw new NullReferenceException("There is no player in the game !");
        return players[0];
    }
}