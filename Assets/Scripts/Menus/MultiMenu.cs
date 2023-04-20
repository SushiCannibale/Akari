using Unity.Netcode;
using UnityEngine.SceneManagement;

public class MultiMenu : MenuBase
{
    public void Host()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene(GameUtils.Scenes.BossRush, LoadSceneMode.Single);
    }

    public void Server()
    {
        NetworkManager.Singleton.StartServer();
    }

    public void Client()
    {
        NetworkManager.Singleton.StartClient();
        NetworkManager.Singleton.SceneManager.LoadScene(GameUtils.Scenes.BossRush, LoadSceneMode.Single);
    }
}