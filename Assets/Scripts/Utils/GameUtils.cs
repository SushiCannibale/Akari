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
}