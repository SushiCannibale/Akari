using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Object = UnityEngine.Object;

public static class LevelLoader
{
    public enum Zones
    {
        Meadows,
        Desert,
        Snowlands,
        TheVoid
    }
    public enum AkariScene
    {
        LevelSpawn,
        LevelValley,
        PunchingArea,
        
    }
    
    public static void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public static void LoadScene(AkariScene scene)
    {
        LoadScene(scene.ToString());
    }
}
