using System;
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
    public GameObject optionsMenu;
    
    private bool pauseGame = true;
    private bool gameStarted = false;

    private void Start()
    {
        GameUtils.PauseGameState(true);
    }

    public void Quit()
    {
        Application.Quit(0);
    }

    /* Main menu */
    public void Play()
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

    public void Options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    /* Pause menu */
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !SceneManager.GetActiveScene().name.Equals("Bootstrap"))
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

    public void MainMenu()
    {
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
        GameUtils.PauseGameState(true);
        pauseGame = true;
    }
}
