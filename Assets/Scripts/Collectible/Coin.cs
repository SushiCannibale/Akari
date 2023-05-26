using System;
using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    [SerializeField] private AudioSource source;
    public void Collect(Player collector)
    {
        source.Play();
        collector.coins++;
        // Mettre un délai avant de destroy sinon le son n'est pas joué
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.Rotate(0f, 1f, 0f);
    }
}