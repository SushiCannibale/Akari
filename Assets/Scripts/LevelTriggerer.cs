using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;

public class LevelTriggerer : MonoBehaviour
{
    public string toScene;
    public static event Action<string, string> PlayerEnterZone;

    public void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        
        if (obj.CompareTag("Player")) {
            PlayerEnterZone?.Invoke(gameObject.tag, toScene);
        }
    }

    // private void OnTriggerExit(Collider other)
    // {
    //     GameObject obj = other.gameObject;
    //     
    //     if (obj.CompareTag("Player")) {
    //         PlayerExitZone?.Invoke(gameObject.tag, toScene);
    //     }
    // }
}
