using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiMenu : MenuBase
{
    [SerializeField] private ClientConnectionMenu menu;
    public void Host()
    {
        NetworkManager.Singleton.StartHost();
        NetworkManager.Singleton.SceneManager.LoadScene(Util.Scenes.BossRush, LoadSceneMode.Single);
    }

    // public void Server()
    // {
    //     NetworkManager.Singleton.StartServer();
    // }

    public void Client()
    {
        NextMenu(menu);
    }
}