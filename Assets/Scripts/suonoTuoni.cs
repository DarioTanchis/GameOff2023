using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suonoTuoni : MonoBehaviour
{

    [SerializeField] AudioSource audioTuono;
    [SerializeField] float min, max;
    float tempoTuon = 0f;
    float tempoPassato = 0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("fotonico", tempoTuon, tempoTuon);
    }

    // Update is called once per frame
    void Update()
    {
        if(tempoTuon == 0f)
        {
            tempoTuon = Random.Range(min, max);
        }
            
        tempoPassato += Time.deltaTime;
        if(tempoPassato >= tempoTuon)
        {
            fotonico();
            tempoPassato = 0f;
            tempoTuon = 0f;
        }
        
    }

    private void fotonico()
    {
        audioTuono.Play();
    }
}
