using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    Light light;
    [SerializeField] float minDelay = 3;
    [SerializeField] float maxDelay = 5;
    [SerializeField] float flickerLenght = .3f;
    [SerializeField] float flickerIntensity = 1.5f;
    float intensity;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        intensity = light.intensity;

        StartCoroutine(StartFlicker());
    }

    IEnumerator StartFlicker()
    {
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

        StartCoroutine(FlickerLight());
    }

    IEnumerator FlickerLight()
    {
        float t = Random.Range(minDelay, maxDelay);

        yield return new WaitForSeconds(t);

        float startTime = Time.time;
        float targetIntensity = Random.Range(intensity / flickerIntensity, intensity * flickerIntensity);

        while (Time.time - startTime < flickerLenght)
        {
            light.intensity = Mathf.Lerp(light.intensity, targetIntensity, (Time.time - startTime) / flickerLenght);
            yield return null;
        }

        startTime = Time.time;

        while (Time.time - startTime < flickerLenght)
        {
            light.intensity = Mathf.Lerp(light.intensity, intensity, (Time.time - startTime) / flickerLenght);
            yield return null;
        }

        StartCoroutine(FlickerLight());
    }
}
