using System;
using System.Collections;
using UnityEngine;

public class GuardianCore : MonoBehaviour, IDamageable
{
    private StoneGuardian guardian;
    [SerializeField] private Material blinkMaterial;
    [SerializeField] private float blinkInterval;

    private void Awake()
    {
        guardian = GetComponentInParent<StoneGuardian>();
    }

    public void Hurt(float amount)
    {
        guardian.Hurt(amount);
        StartCoroutine(HurtBlinkFor(gameObject, blinkInterval, 2));
    }

    public IEnumerator HurtBlinkFor(GameObject obj, float blinkInterval, float seconds)
    {
        float time = 0f;
        Renderer renderer = obj.GetComponent<MeshRenderer>();

        Material defMat = renderer.material;
        
        while (time < seconds)
        {
            if (time % blinkInterval == 0)
            {
                Debug.Log("Blinked !");
                renderer.material = blinkMaterial;
            }
                
            else
                renderer.material = defMat;
            
            time += Time.deltaTime;
            yield return null;
        }

        renderer.material = defMat;
    }
}