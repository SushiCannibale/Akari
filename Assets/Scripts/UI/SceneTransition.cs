using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private float fadeTime;
    [SerializeField] private Animator animator;
    
    public void TransitionTo(string scene)
    {
        StartCoroutine(Fade(scene));
    }

    IEnumerator Fade(string scene)
    {
        animator.SetTrigger("Fade");
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
    }
}