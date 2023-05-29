using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class InteractibleSprite : MonoBehaviour, IInteractible
{
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Sprite alt;
    [SerializeField] private AudioSource hurtSound;
    [SerializeField] private float delay;

    private bool canInteract = true;

    IEnumerator Kill()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - 0.1f);
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    public void Interact(Player interactor)
    {
        if (!canInteract)
            return;

        canInteract = false;
        foreach (AudioSource src in FindObjectsOfType<AudioSource>())
            src.Stop();
    
        sprite.sprite = alt;
        hurtSound.Play();
        StartCoroutine(Kill());
    }
}