using System;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleLever : MonoBehaviour, IInteractible
{
    [SerializeField] private List<PuzzleCompound> bounded;
    [SerializeField] private bool isActive;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact(Player interactor)
    {
        isActive = !isActive;
        animator.SetBool("IsActive", isActive);
        bounded.ForEach(comp => comp.IsActive = isActive);
    }
}