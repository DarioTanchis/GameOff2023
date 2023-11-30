using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    bool played = false;
    private void Start() {
        
    }

    [SerializeField]List<AudioSource> sourceList;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !played)
        {
            foreach (AudioSource source in sourceList)
            {
                source.Play();
               
            }
            played = true;
            this.enabled = false;
        }
        
    }
}
