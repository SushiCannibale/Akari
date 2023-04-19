using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

public class LevelTriggerer : MonoBehaviour
{
    [SerializeField] private string toScene;
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out Player player)) 
        {
            if (gameObject.CompareTag("AnimatedPortal"))
                LoadSceneAnimated(toScene);
            else
                SceneManager.LoadScene(toScene);
        }
    }
    
    public void LoadSceneAnimated(string scene)
    {
        /* !!!!!! Ca suppose de ne pas avoir d'autre Animator dans le Canvas !!!!!!! */
        Animator animator = GameManager.Instance.Canvas.GetComponentInChildren<Animator>();
        StartCoroutine(PlayAnimation(scene, animator, 1f));
    }
    
    IEnumerator PlayAnimation(string scene, Animator animator, float waitTime)
    {
        animator.SetTrigger("In");
        yield return new WaitForSeconds(waitTime);
        
        SceneManager.LoadScene(scene);
        
        animator.SetTrigger("Out");
        yield return new WaitForSeconds(waitTime);
    }
}
