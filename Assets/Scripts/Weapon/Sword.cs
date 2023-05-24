using System;
using System.Buffers;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private float damage;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Swing()
    {
        animator.SetTrigger("Swing");
    }
}