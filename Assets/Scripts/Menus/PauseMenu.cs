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
            Pause(!GameManager.Instance.IsGamePaused);
        }
    }

    /* Aussi bind à un bouton */
    public void Pause(bool flag)
    {
        GameManager.Instance.IsGamePaused = flag;
        Util.PauseGameState(flag);
        holder.SetActive(flag);
    }

    /* Bind à un bouton */
    public void MainTitle()
    {
        Pause(false);
        GameManager.Instance.SaveAndLoadAsync(Util.Scenes.MainTitle, LoadSceneMode.Single);
    }
}