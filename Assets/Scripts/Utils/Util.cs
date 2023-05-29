using System;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static void PauseGameState(bool flag) => Time.timeScale = flag ? 0f : 1f;

    public static class Scenes {
        public static string MainTitle = "MainTitle";
        public static string BossRush = "BossRush";
        public static string FirstGameScene = "Plaines01";
        public static string GameOver = "GameOver";
    }

    public static class Keys
    {
        public static KeyCode INTERACT = KeyCode.E;
        public static KeyCode INSTAKILL = KeyCode.K;
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