using System;
using System.Collections.Generic;
using UnityEngine;

public class WtfComponent : MonoBehaviour
{
    [Header("All inclusive")]
    [SerializeField] protected int minWtf;
    [SerializeField] protected int maxWtf;
    
    [SerializeField] protected List<GameObject> toEnable;
    [SerializeField] protected List<GameObject> toDisable;

    private void Awake()
    {
        int wtf = GameManager.Instance.data.wtfValue;

        if (!(minWtf <= wtf && wtf <= maxWtf))
        {
            Destroy(gameObject);
            return;
        }
        
        toEnable.ForEach(obj => obj.SetActive(true));
        toDisable.ForEach(obj => obj.SetActive(false));
    }
}