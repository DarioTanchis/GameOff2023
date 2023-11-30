using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{

    [SerializeField]List<AudioSource> sourceList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (AudioSource source in sourceList)
            {
                source.Play();
            }
            this.gameObject.SetActive(false);
        }
        
    }
}
