using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public abstract class PlayerCheat : Cheat
{
    protected Player Player;
    protected virtual void Awake()
    {
        Player = GetComponent<Player>();
    }
}