using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class LevelTriggerer : MonoBehaviour
{
    [SerializeField] private string toScene;
    public static event Action<string, string> PlayerEnterZone;

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player)) 
        {
            LevelLoader.LoadScene(toScene);
            // PlayerEnterZone?.Invoke(gameObject.tag, toScene);
        }
    }
}
