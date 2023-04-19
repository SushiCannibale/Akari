using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause(!GameManager.Instance.IsPaused);
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
        LevelLoader.LoadScene(GameUtils.Scenes.MainTitle);
    }
}