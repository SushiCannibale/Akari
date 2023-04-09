using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DarkZoneTransition : MonoBehaviour
{
    public Animator transition;
    public GameObject darkCircle;
    public float waitTime;

    private void Awake()
    {
        LevelTriggerer.PlayerEnterZone += onEnterZone;
        // LevelTriggerer.PlayerExitZone += onExitZone;
    }

    public void onEnterZone(string zoneTag, string scene)
    {
        if (zoneTag.Equals("DarkZone"))
            StartCoroutine(MakeTransition(waitTime, scene));
        else
            LevelLoader.LoadScene(scene);
    }

    // public void onExitZone(string zoneTag, string scene)
    // {
    //     if (zoneTag.Equals("DarkZone"))
    //         StartCoroutine(ExitTransition(waitTime));
    //     else
    //         LevelLoader.LoadScene(scene);
    // }

    IEnumerator MakeTransition(float waitTime, string scene)
    {
        darkCircle.SetActive(true);
        transition.SetTrigger("Enter");
        yield return new WaitForSeconds(waitTime);
        LevelLoader.LoadScene(scene);
        transition.SetTrigger("Exit");
        yield return new WaitForSeconds(waitTime);
        darkCircle.SetActive(false);
    }

    // IEnumerator ExitTransition(float waitTime)
    // {
    //     transition.SetTrigger("Exit");
    //     yield return new WaitForSeconds(waitTime);
    //     darkCircle.SetActive(false);
    // }
}
