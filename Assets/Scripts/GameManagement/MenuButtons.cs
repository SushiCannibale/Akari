using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtons : AbstractInterScene
{
    public GameObject pauseMenu;

    public GameObject mainMenu;
    private bool pause = false;
    
    public void MainPlay()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        pause = false;
        LevelLoader.LoadScene("LevelSpawn");
    }

    public void MainQuit()
    {
        Application.Quit(0);
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pause)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }

    public void Quit()
    {
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);
        pause = true;
        // LevelLoader.LoadScene("Bootstrap");
    }
}
