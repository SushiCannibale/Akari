using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MenuBase
{
    [SerializeField] private PlayMenu playMenu;
    [SerializeField] private OptionsMenu optionsMenu;

    public void Play() => NextMenu(playMenu);
    public void Options() => NextMenu(optionsMenu);

    protected override void Update() { }
}
