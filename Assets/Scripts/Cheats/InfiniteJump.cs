using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ONLY ASSIGN IT TO A PLAYER ! */
public class InfiniteJump : CheatCode
{
    private void Start()
    {
        Name = "infinitejump";
        ResponseText = "Congratulations, you can now reach the moon !";
    }

    public override void Activate()
    {
        Player player = GetComponent<Player>();
        player.infiniteJump = true;
    }
}
