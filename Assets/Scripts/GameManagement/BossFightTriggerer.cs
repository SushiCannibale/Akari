using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BossFightTriggerer : MonoBehaviour
{
    [SerializeField] private Boss bossFight;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            bossFight.StartFight(player);
        }
    }
}