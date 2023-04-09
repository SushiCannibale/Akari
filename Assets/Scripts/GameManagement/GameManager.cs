using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : AbstractInterScene
{
    public static void DestroyInScene(string sceneName, string[] names)
    {
        foreach (GameObject gameobject in SceneManager.GetSceneByName(sceneName).GetRootGameObjects().Where(obj => names.Contains(obj.name)))
            Destroy(gameobject);
    }
}
