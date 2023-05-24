using System;
using System.Collections.Generic;
using UnityEngine;

public class GameUtils
{
    public static void PauseGameState(bool flag) => Time.timeScale = flag ? 0f : 1f;
    
    public static class Scenes {
        public static string Bootstrap = "Bootstrap";
        public static string MainTitle = "MainTitle";
        public static string BossRush = "BossRush";
    }

    public static class Keys
    {
        public static KeyCode INTERACT = KeyCode.E;
    }

    public static class Layers
    {
        public static int Enemy = 3;
    }

    public static class Math
    {
        public static GameObject CloserTo(List<GameObject> list, GameObject other)
        {
            GameObject obj = list[0];
            float dist = Vector3.Distance(other.transform.position, list[0].transform.position);
            foreach (GameObject o in list)
            {
                float d = Vector3.Distance(other.transform.position, o.transform.position);
                if (d < dist)
                {
                    dist = d;
                    obj = o;
                }
            }

            return obj;
        }
    }
}