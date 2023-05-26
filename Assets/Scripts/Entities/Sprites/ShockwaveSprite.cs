using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ShockwaveSprite : MonoBehaviour, IDamageProvider
{
    [SerializeField] private float damage; // placeholder
    
    [SerializeField] private Vector3 scaleSpeed;
    [SerializeField] private float alphaSpeed;
    
    [SerializeField] private Vector3 maxScale;
    [SerializeField] private SpriteRenderer sprite;

    private void Update()
    {
        if (sprite.color.a <= 0 || transform.localScale == maxScale)
            Destroy(gameObject);

        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - alphaSpeed * Time.deltaTime);
        transform.localScale += scaleSpeed * Time.deltaTime;
    }
    public bool IsLethal() => true;
    public float DamageAmount() => damage;
}