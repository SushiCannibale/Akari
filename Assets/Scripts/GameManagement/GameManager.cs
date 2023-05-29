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
    
    [Header("File storage config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool createDataIfNull;

    [SerializeField] private List<string> dontSaveScenes;

    public GameData data { get; private set; }
    private List<IPersistentData> persistentDataObjects;
    private FileDataHandler handler;
    
    public bool IsGamePaused { get; set; }
    
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Il y a plus d'un GameManager dans la scène, il a été grand remplacé !");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        handler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        persistentDataObjects = FindObjectsOfType<MonoBehaviour>().OfType<IPersistentData>().ToList();
        LoadData();
    }

    public void CreateData()
    {
        data = new GameData();
    }
    
    public void LoadData()
    {
        // load from the file
        data = handler.Load();

        if (data == null && createDataIfNull)
        {
            CreateData();
        }

        if (data == null)
            Debug.LogError("No data could be found !");
        
        // Push the GameData to other scripts to load from
        persistentDataObjects.ForEach(obj => obj.LoadFrom(data));
    }

    public void SaveData()
    {
        if (data == null)
        {
            Debug.LogError("No data was found.");
            return;
        }
        
        // Push the GameData to other scripts to save on
        persistentDataObjects.ForEach(obj => obj.SaveTo(data));
        
        // Save data to file
        string currScene = SceneManager.GetActiveScene().name;
        if (!dontSaveScenes.Contains(currScene))
            data.scene = currScene;
        
        handler.Save(data);
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }

    public void SaveAndLoadAsync(string scene, LoadSceneMode mode)
    {
        SaveData();
        SceneManager.LoadSceneAsync(scene, mode);
    }

    // public bool HasGameData() => data != null;
}
