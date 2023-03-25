using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    public static void LoadScene(string sceneName)
    {
        LevelLoader.LoadScene(sceneName);
    }

    public static void Quit()
    {
        Application.Quit(0);
    }
}
