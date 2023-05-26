using System;
using UnityEngine;

public class CameraShifter : MonoBehaviour
{
    [SerializeField] private Vector3 newOffset;
    [SerializeField] private float smooth;
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.PlayerCamera.offset = newOffset;
        // GameManager.Instance.PlayerCamera.transform.position = Vector3.Lerp(GameManager.Instance.PlayerCamera.offset, newOffset, smooth);
    }
}