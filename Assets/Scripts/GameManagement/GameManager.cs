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
    [SerializeField] private GameCanvas gameUIPrefab;
    [SerializeField] private DialogueManager dialogueManagerPrefab;

    [SerializeField] private string gameSceneName;
    [SerializeField] private string firstScene;

    public bool IsPlaying { get; private set; }
    public bool IsPaused { get; private set; }
    
    public Player Player { get; private set; }
    public PlayerCamera PlayerCamera { get; private set; }
    public PlayerLight PlayerLight { get; private set; }
    public GameCanvas Canvas { get; private set; }
    public DialogueManager DialogueManager { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            
            IsPlaying = false;
            IsPaused = false;
            
            SceneManager.LoadScene(firstScene);
        } 
        else
            throw new ApplicationException("Il y a plus d'un <GameManager> !");
    }

    public void Pause(bool f) => IsPaused = f;

    public void NewGame()
    {
        SceneManager.LoadScene(gameSceneName);

        DialogueManager = Instantiate(dialogueManagerPrefab);
        
        Player = Instantiate(playerPrefab);
        PlayerCamera = Instantiate(playerCamPrefab).GetComponent<PlayerCamera>();
        PlayerLight = Instantiate(playerLightPrefab).GetComponent<PlayerLight>();
        Canvas = Instantiate(gameUIPrefab);
        
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

    public void Annihilate(Predicate<GameObject> p)
    {
        foreach(GameObject gameobject in SceneManager.GetActiveScene().GetRootGameObjects().Where(go => p(go)))
            Destroy(gameobject);
    }
}
