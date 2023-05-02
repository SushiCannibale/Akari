using System;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    public static Canvas Instance;

    private void Awake()
    {
        if (Instance is null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
            throw new ApplicationException("Il y a plus d'un <Canvas>");
    }
}