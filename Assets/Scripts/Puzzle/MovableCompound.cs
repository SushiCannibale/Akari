using System;
using UnityEngine;

public class MovableCompound : PuzzleCompound
{
    [SerializeField] private Vector3 finalPosition;
    [SerializeField] private float smooth;

    public override void Action()
    {
        transform.position = Vector3.Lerp(transform.position, finalPosition, smooth * Time.deltaTime);
    }
}