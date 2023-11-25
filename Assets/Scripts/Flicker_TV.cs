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
    [SerializeField] Light light;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        mat = meshRenderer.material;
        mat.SetColor("_EmissionColor", Color.black);
        light.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastSwitchTime > flickerDuration)
        {
            lastSwitchTime = Time.time;
            turnedOn = !turnedOn;
            light.enabled = turnedOn;
            mat.SetColor("_EmissionColor", turnedOn ? Color.white : Color.black);
        } 

    }
}
