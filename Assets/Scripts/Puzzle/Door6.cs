using UnityEngine;

public class Door6 : WtfComponent, IInteractible
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource doorSound;
    private bool open = false;
    public void Interact(Player interactor)
    {
        open = !open;
        doorSound.Play();
        animator.SetBool("Open", open);
    }
}