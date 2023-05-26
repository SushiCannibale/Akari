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
                GameManager.Instance.SaveAndLoadAsync(toScene, LoadSceneMode.Single);
        }
    }
    
    public void LoadSceneAnimated(string scene)
    {
        Animator animator = Canvas.Instance.GetComponentInChildren<DarkZoneTransition>().GetComponent<Animator>();
        StartCoroutine(PlayAnimation(scene, animator, 1f));
    }
    
    IEnumerator PlayAnimation(string scene, Animator animator, float waitTime)
    {
        animator.SetTrigger("In");
        yield return new WaitForSeconds(waitTime);
        
        GameManager.Instance.SaveAndLoadAsync(scene, LoadSceneMode.Single);
        
        animator.SetTrigger("Out");
        yield return new WaitForSeconds(waitTime);
    }
}
