using System;
using TMPro;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    public static Canvas Instance { get; private set; }
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Il y a déjà un Canvas dans la scène, il a été grand remplacé");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}