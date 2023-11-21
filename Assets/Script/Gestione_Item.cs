using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestione_Item : MonoBehaviour
{

    public Transform playerItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Fa sparire l'oggetto da terra e comparire quello in mano
    public void prediOggetto(GameObject item, GameObject playerItem) {
        item.gameObject.SetActive(false);
        playerItem.gameObject.SetActive(true);

    }
}
