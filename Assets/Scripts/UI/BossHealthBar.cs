using System;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform rt;

    private void Update()
    {
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 182 - 8);
    }
}