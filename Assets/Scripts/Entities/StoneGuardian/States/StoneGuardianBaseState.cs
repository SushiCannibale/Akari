using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StoneGuardianBaseState
{
    public abstract void Start(StoneGuardian guardian);
    public abstract void Update(StoneGuardian guardian);

    public abstract void End(StoneGuardian guardian);
}
