using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Object = UnityEngine.Object;

public class LevelLoader
{
    public static void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
