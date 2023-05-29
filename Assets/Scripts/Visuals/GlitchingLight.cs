using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GlitchingLight : MonoBehaviour
{
    [SerializeField] private Light light;
    [SerializeField] private float minNewIntensity;
    [SerializeField] private float balanceAmplitude;
    [Header("All inclusive")]
    [SerializeField] private float minInterval;
    [SerializeField] private float maxInterval;
    [SerializeField] private float minTimeOff;
    [SerializeField] private float maxTimeOff;

    private float baseIntensity;
    private float timer;
    private float interval;
    private float balanceTimer;
    private void Awake()
    {
        baseIntensity = light.intensity;
    }

    private void Start()
    {
        timer = 0f;
        balanceTimer = 0f;
        interval = Random.Range(minInterval, maxInterval);
    }

    private void Update()
    {
        Balance(balanceAmplitude);
        if (timer < interval)
        {
            timer += Time.deltaTime;
            return;
        }
        
        timer = 0f;
        interval = Random.Range(minInterval, maxInterval);
        StartCoroutine(OffFor(Random.Range(minNewIntensity, baseIntensity), Random.Range(minTimeOff, maxTimeOff)));
    }

    IEnumerator OffFor(float intensity, float seconds)
    {
        light.intensity = intensity;
        yield return new WaitForSeconds(seconds);
        light.intensity = baseIntensity;
    }

    private void Balance(float amplitude)
    {
        transform.rotation = Quaternion.Euler(90f + transform.rotation.x + amplitude * Mathf.Sin(balanceTimer), 0f, 0f);
        balanceTimer = (balanceTimer + Time.deltaTime) % 360;
    }
}