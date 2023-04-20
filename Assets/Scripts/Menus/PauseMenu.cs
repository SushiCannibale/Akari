using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject holder;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause(!GameManager.Instance.IsPaused);
        }
    }

    /* Aussi bind à un bouton */
    public void Pause(bool flag)
    {
        GameManager.Instance.Pause(flag);
        GameUtils.PauseGameState(flag);
        holder.SetActive(flag);
    }

    /* Bind à un bouton */
    public void MainTitle()
    {
        GameManager.Instance.Annihilate(g => g.name != "GameManager");
        SceneManager.LoadScene(GameUtils.Scenes.MainTitle);
    }
}