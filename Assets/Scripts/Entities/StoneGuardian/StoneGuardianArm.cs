using System;
using UnityEngine;

public class StoneGuardianArm : MonoBehaviour
{
    private StoneGuardian parent;
    public bool CollideWithPlayer { get; private set; }
    public bool CollideWithWall { get; private set; }

    private void Awake()
    {
        CollideWithPlayer = false;
        CollideWithWall = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            CollideWithPlayer = true;
            CollideWithWall = false;
        }
        else
        {
            CollideWithWall = true;
            CollideWithPlayer = false;
        }
    }
}