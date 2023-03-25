using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class LevelTriggerer : MonoBehaviour
{
    public string toScene;
    
    public void OnTriggerEnter(Collider collider)
    {
        GameObject gameObject = collider.gameObject;
        
        if (gameObject.CompareTag("Player")) { // Seul le player peut charger une zone
            LevelLoader.LoadScene(toScene);
        }
    }
}
