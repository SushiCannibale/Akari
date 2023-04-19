using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if (GameManager.Instance.IsPaused)
                Pause(false);
            else
                Pause(true);
        }
    }

    /* Aussi bind à un bouton */
    public void Pause(bool flag)
    {
        GameManager.Instance.Pause(flag);
        GameUtils.PauseGameState(flag);
    }

    /* Bind à un bouton */
    public void MainTitle()
    {
        GameManager.Instance.Annihilate(g => g.name != "GameManager");
        SceneManager.LoadScene(GameUtils.Scenes.MainTitle);
    }
}