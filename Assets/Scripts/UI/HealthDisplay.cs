using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private AbstractGuardianBoss boss;
    
    [SerializeField] private RectTransform holder;
    [SerializeField] private CanvasGroup holderGroup;
    
    [SerializeField] private RectTransform bar;
    [SerializeField] private float barMaxSize;

    [SerializeField] private float initialFillSPeed;

    private float size;
    private bool shouldUpdate;

    private void Start()
    {
        holderGroup.alpha = 0f;
        holder.offsetMax = new Vector2(barMaxSize, holder.offsetMax.y);
        bar.offsetMax = new Vector2(-barMaxSize, 0f);
    }

    private void Update()
    {
        if (!shouldUpdate)
            return;
        
        if (!boss.IsAlive())
        {
            StartCoroutine(Disappear());
            shouldUpdate = false;
            return;
        }
        
        size = boss.Health * (barMaxSize / boss.MaxHealth) - barMaxSize;
        if (size <= -barMaxSize)
            return;

        bar.offsetMax = new Vector2(size, 0f);
    }
    
    public void Appear()
    {
        StartCoroutine(PerformAppear());
    }

    IEnumerator Disappear()
    {
        while (holderGroup.alpha > 0f)
        {
            holderGroup.alpha -= Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

    IEnumerator PerformAppear()
    {
        while (holderGroup.alpha < 1f)
        {
            holderGroup.alpha += Time.deltaTime;
            yield return null;
        }

        StartCoroutine(Fill());
    }

    IEnumerator Fill()
    {
        while (bar.offsetMax.x < 0f)
        {
            bar.offsetMax += new Vector2(initialFillSPeed, 0f);
            yield return null;
        }
        shouldUpdate = true;
    }
}