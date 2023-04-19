using System;
using UnityEngine;

public class PlayerLight : MonoBehaviour
{
    /* L'angle permet de modifier le cycle jour / nuit */
    [SerializeField] private float startAngle;
    /* De combien l'angle augmente à chaque Update */
    [SerializeField] private float deltaAngle; 
    
    private float angle;
    private Player owner;

    public void SetOwner(Player player) => owner = player;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        angle = startAngle;
    }

    private void Update()
    {
        angle += deltaAngle * Time.deltaTime;
        transform.rotation = Quaternion.Euler(angle, 0f, 0f);
    }
}