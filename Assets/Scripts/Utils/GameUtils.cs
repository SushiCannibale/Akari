using System.Collections;
using UnityEngine;

namespace Utils
{
    public class GameUtils
    {
        public static void PauseGameState(bool flag)
        {
            Time.timeScale = flag ? 0f : 1f;
        }
    }
}