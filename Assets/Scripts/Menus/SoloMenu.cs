public class SoloMenu : MenuBase
{
    public void NewGame() => GameManager.Instance.NewGame();
    public void Continue() => GameManager.Instance.LoadGame();
}