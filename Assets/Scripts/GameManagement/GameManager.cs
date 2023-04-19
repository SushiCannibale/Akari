using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private Player playerPrefab;
    [SerializeField] private PlayerCamera playerCamPrefab;
    [SerializeField] private PlayerLight playerLightPrefab;
    
    [SerializeField] private Canvas gameUIPrefab;

    [SerializeField] private string gameSceneName;
    [SerializeField] private string firstScene;

    public bool IsPlaying { get; private set; }
    public bool IsPaused { get; private set; }
    
    public Player Player { get; set; }
    public PlayerCamera PlayerCamera { get; set; }
    
    public PlayerLight PlayerLight { get; set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            
            IsPlaying = false;
            IsPaused = false;
            
            LevelLoader.LoadScene(firstScene);
        } 
        else
            throw new ApplicationException("Il y a plus d'un GameManager dans le jeu");
    }

    public void Pause(bool f) => IsPaused = f;

    public void NewGame()
    {
        LevelLoader.LoadScene(gameSceneName);
        Player = Instantiate(playerPrefab);
        PlayerCamera = Instantiate(playerCamPrefab).GetComponent<PlayerCamera>();
        PlayerLight = Instantiate(playerLightPrefab).GetComponent<PlayerLight>();
        
        Player.SetCamera(PlayerCamera);
        PlayerCamera.SetTarget(Player.transform);
        PlayerLight.SetOwner(Player);
        
        IsPlaying = true;
        IsPaused = false;
    }

    public void Quit()
    {
        IsPlaying = false;
        Application.Quit();
    }

    public void LoadGame()
    {
        IsPlaying = true;
        IsPaused = false;
        // TODO : Charger la save
    }
}
