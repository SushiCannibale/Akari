using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DarkZoneTransition : MonoBehaviour
{
    [SerializeField] private string triggerIn;
    [SerializeField] private string triggerOut;
}