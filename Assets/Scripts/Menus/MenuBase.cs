using System;
using UnityEngine;

public abstract class MenuBase : MonoBehaviour
{
    private MenuBase previousMenu;
    public void Quit() => Application.Quit();
    public void NextMenu(MenuBase to)
    {
        to.previousMenu = this;
        to.gameObject.SetActive(true);
        
        gameObject.SetActive(false);
    }

    public void Back()
    {
        gameObject.SetActive(false);
        previousMenu.gameObject.SetActive(true);
    }

    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Back();
    }
}