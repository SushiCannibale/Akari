using UnityEngine;
using UnityEngine.SceneManagement;

public class SoloMenu : MenuBase
{
    [SerializeField] private string startingScene;
    public void NewGame()
    {
        GameManager.Instance.CreateData();
        FindObjectOfType<SceneTransition>().TransitionTo(startingScene);
        GameManager.Instance.SaveData();
    }

    public void Continue()
    {
        GameManager.Instance.LoadData();
        FindObjectOfType<SceneTransition>().TransitionTo(GameManager.Instance.data.scene);
    }
}