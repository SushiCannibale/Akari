using UnityEngine.SceneManagement;

public class GameoverMenu : MenuBase
{
    public void Continue()
    {
        GameManager.Instance.LoadData();
        SceneManager.LoadSceneAsync(GameManager.Instance.data.scene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Util.Scenes.MainTitle);
    }
}