using System;
using UnityEngine;

public class BossBarTriggerer : MonoBehaviour
{
    [SerializeField] private HealthDisplay display;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            display.enabled = true;
            display.Appear();
            Destroy(gameObject);
        }
    }
}