using System;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    [SerializeField] private AudioSource source;
    private bool collected;

    private void Start()
    {
        collected = false;
    }

    public void Collect(Player collector)
    {
        if (collected)
            return;

        collected = true;
        source.Play();
        collector.coins++;
        StartCoroutine(CoinSound(0.5f));
    }

    private void Update()
    {
        transform.Rotate(0f, 1f, 0f);
    }

    IEnumerator CoinSound(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}