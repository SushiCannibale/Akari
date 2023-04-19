using System;
using UnityEngine;
using Utils;

public class GameScreen : MenuBase
{
    [SerializeField] private GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Instance.IsPaused)
                Resume();
            else
                Pause();
        }
    }

    /* Bind à un bouton */
    public void Resume()
    {
        pauseMenu.SetActive(false);
        GameUtils.PauseGameState(false);
        GameManager.Instance.Pause(true);
    }
    
    /* Bind à un bouton */
    public void Pause()
    {
        pauseMenu.SetActive(true);
        GameUtils.PauseGameState(true);
        GameManager.Instance.Pause(true);
    }
    
    /* Bind à un bouton */
    public void MainMenu()
    {
        // TODO : Save avant de load, vu que tou est supprimé
        LevelLoader.LoadScene("MainTitle");
    }
}