using System;
using UnityEngine;

[Serializable]
public class SerializedGuardianData
{
    [SerializeField] public Vector3 position;
    [SerializeField] public bool isDead;

    public SerializedGuardianData(Vector3 pos, bool isdead)
    {
        position = pos;
        isDead = isdead;
    }
}