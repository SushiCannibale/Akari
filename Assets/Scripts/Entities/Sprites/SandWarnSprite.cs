using System;
using UnityEngine;

public class SandWarnSprite : MonoBehaviour
{
    private Vector3 scaleSpeed;
    [SerializeField] private float alphaSpeed;
    
    [SerializeField] private SpriteRenderer sprite;

    public void SummonAt(Vector3 pos, Vector3 speed)
    {
        scaleSpeed = speed;
        transform.position = pos;
    }

    private void Update()
    {
        if (sprite.color.a <= 0 || transform.localScale == Vector3.zero)
            Destroy(gameObject);

        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - alphaSpeed * Time.deltaTime);
        transform.localScale -= scaleSpeed * Time.deltaTime;
    }
}