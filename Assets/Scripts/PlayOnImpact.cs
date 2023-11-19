using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnImpact : MonoBehaviour
{
    AudioSource source;
    [SerializeField] float pitchVariance = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        source.pitch = 1 + Random.Range(-pitchVariance, pitchVariance);
        source.Play();
    }
}
