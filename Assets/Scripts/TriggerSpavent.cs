using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpavent : MonoBehaviour
{
    [SerializeField] GameObject spavent;
    [SerializeField] AudioSource audioSpavent;
    [SerializeField] float tempoSpavent;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spavent.SetActive(true);
            audioSpavent.Play();
            StartCoroutine(spaventco());
           
        }
    }

    IEnumerator spaventco()
    {
        yield return new WaitForSecondsRealtime(tempoSpavent);
        spavent.SetActive(false);
        this.gameObject.SetActive(false);
    } 
}