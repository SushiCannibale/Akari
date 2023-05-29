using System;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClientConnectionMenu : MenuBase
{
    [SerializeField] private TMP_Text ip;

    public void Connect()
    {

        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ip.text, 7777, "0.0.0.0");
        NetworkManager.Singleton.StartClient();
        // NetworkManager.Singleton.SceneManager.LoadScene(Util.Scenes.BossRush, LoadSceneMode.Single);
        // try
        // {
        //     NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData(ip.text, 7777);
        //     NetworkManager.Singleton.StartClient();
        // }
        // catch (Exception e)
        // {
        //     Debug.Log(e);
        // }

        // NetworkManager.Singleton.SceneManager.LoadScene(Util.Scenes.BossRush, LoadSceneMode.Single);
    }
}