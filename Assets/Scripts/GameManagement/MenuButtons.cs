using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    /*
     * Fonctions pouvant être utilisés lorsqu'on clique sur un bouton (cf. onClick)
     */
    public static void LoadScene(string sceneName)
    {
        LevelLoader.LoadScene(sceneName);
    }

    public static void Quit()
    {
        Application.Quit(0);
    }
}
