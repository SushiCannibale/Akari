using System;
using UnityEngine;

public class FacingSprite : MonoBehaviour
{
    [SerializeField] private Transform target;
    // [SerializeField] private float smoothness;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0f, target.rotation.eulerAngles.y, 0f);
    }
}