using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonJump : PlayerCheat
{
    protected override void Awake()
    {
        base.Awake();
        Name = "moonjump";
        DesacName = "!" + Name;
        ResponseText = "Congratulations, you can now reach the moon !";
    }

    public override void Activate()
    {
        base.Activate();
        Player.SetMoonJump(true);
    }

    public override void Desactivate()
    {
        base.Desactivate();
        Player.SetMoonJump(false);
    }
}
