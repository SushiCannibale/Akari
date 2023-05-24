using System;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private int startDist;
    private AbstractBoss boss;
    private int dist;
    
    private Image bar;

    private void Start()
    {
        boss = GetComponentInChildren<AbstractBoss>();
    }

    private void Update()
    {
        
    }
}