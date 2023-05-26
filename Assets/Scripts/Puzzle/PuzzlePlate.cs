using System;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePlate : MonoBehaviour
{
    [SerializeField] private List<PuzzleCompound> bounded;
    [SerializeField] private bool isActive;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isActive = true;
        animator.SetBool("Pressed", isActive);
        bounded.ForEach(comp => comp.IsActive = isActive);
    }

    private void OnCollisionExit(Collision other)
    {
        isActive = false;
        animator.SetBool("Pressed", isActive);
        bounded.ForEach(comp => comp.IsActive = isActive);
    }
}