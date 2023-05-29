using System;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Vector3 position;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = position;
    }
}   