using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Object = UnityEngine.Object;

public class LevelLoader : MonoBehaviour
{
    public string sceneToLoad;
    public Rigidbody player;
    public Object[] toBring;
    public Vector3 position;

    private void OnTriggerEnter(Collider other)
    {
        foreach (Object obj in toBring)
            DontDestroyOnLoad(obj);
        
        SceneManager.LoadScene(sceneToLoad);
        
        player.position = position;
    }
}
