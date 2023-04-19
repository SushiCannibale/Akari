using UnityEngine;

public class PlayMenu : MenuBase
{
    [SerializeField] private SoloMenu soloMenu;
    [SerializeField] private MultiMenu multiMenu;

    public void Singleplayer() => NextMenu(soloMenu);
    
    public void Multiplayer() => NextMenu(multiMenu);
}