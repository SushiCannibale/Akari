using System;
using UnityEngine;

public class CameraShifter : MonoBehaviour
{
    [SerializeField] private PlayerCamera cam;
    [SerializeField] private Vector3 newOffset;
    // [SerializeField] private float smooth;
    private void OnTriggerEnter(Collider other)
    {
        cam.offset = newOffset;
        GameManager.Instance.SaveData();
        // GameManager.Instance.PlayerCamera.transform.position = Vector3.Lerp(GameManager.Instance.PlayerCamera.offset, newOffset, smooth);
    }
}