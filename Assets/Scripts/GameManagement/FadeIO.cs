using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIO : MonoBehaviour
{
    // private bool faded = false;
    // public float maxDuration;
    //
    // public void Fade()
    // {
    //     CanvasGroup cvg = GetComponent<CanvasGroup>();
    //     StartCoroutine(Execute(cvg, cvg.alpha, faded ? 1 : 0));
    //     faded = !faded;
    // }
    //
    // public IEnumerator Execute(CanvasGroup group, float start, float end)
    // {
    //     float counter = 0f;
    //     while (counter < maxDuration)
    //     {
    //         counter += Time.deltaTime;
    //         group.alpha = Mathf.Lerp(start, end, counter / maxDuration);
    //
    //         yield return null;
    //     }
    // }
}
