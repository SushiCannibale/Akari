using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

public class MenuButtons : AbstractInterScene
{
    public GameObject pauseMenu;
    public GameObject mainMenu;
    
    private bool pauseGame = true;
    private bool gameStarted = false;

    public void MainPlay()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        pauseGame = false;
        GameUtils.PauseGameState(false);

        if (!gameStarted)
        {
            LevelLoader.LoadScene("LevelSpawn");
            gameStarted = true;
        }
    }

    public void MainQuit()
    {
        Application.Quit(0);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (pauseGame)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        GameUtils.PauseGameState(false);
        pauseGame = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        GameUtils.PauseGameState(true);
        pauseGame = true;
    }

    public void Quit()
    {
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
        GameUtils.PauseGameState(false);
        pauseGame = true;
    }
}
