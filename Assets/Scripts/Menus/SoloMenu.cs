using UnityEngine;
using UnityEngine.SceneManagement;

public class SoloMenu : MenuBase
{
    [SerializeField] private string startingScene;
    public void NewGame()
    {
        GameManager.Instance.CreateData();
        GameManager.Instance.SaveAndLoadAsync(startingScene, LoadSceneMode.Single);
    }

    public void Continue()
    {
        GameManager.Instance.LoadData();
        GameManager.Instance.SaveAndLoadAsync(GameManager.Instance.data.scene, LoadSceneMode.Single);
    }
}