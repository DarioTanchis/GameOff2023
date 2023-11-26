using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker_TV : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Material mat;
    [SerializeField] float flickerDuration = .1f;
    bool turnedOn = false;
    float lastSwitchTime;
    [SerializeField] Color flickerColor = Color.white;
    [SerializeField] Light light;
    [SerializeField] float flickerInterval = 4;
    [SerializeField] float flickerLength = 1;
    float flickerStart, lastFlickerEnd;
    bool isFlickering;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        mat = meshRenderer.material;
        mat.SetColor("_EmissionColor", flickerColor);
        light.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFlickering && Time.time - lastFlickerEnd > flickerInterval)
        {
            isFlickering = true;
            flickerStart = Time.time;
        }

        if(isFlickering && Time.time - flickerStart < flickerLength)
        {
            if (Time.time - lastSwitchTime > flickerDuration)
            {
                lastSwitchTime = Time.time;
                turnedOn = !turnedOn;
                light.enabled = turnedOn;
                mat.SetColor("_EmissionColor", turnedOn ? flickerColor : Color.black);
                light.color = flickerColor;
                Debug.Log("Flickering");
            }
        }
        else if (isFlickering)
        {
            mat.SetColor("_EmissionColor", flickerColor);
            light.enabled = true;

            isFlickering = false;
            lastFlickerEnd = Time.time;
        }

    }
}
