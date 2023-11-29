using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp_Item : MonoBehaviour
{

    public Gestione_Item prendimi;                    //script del player che fa sparire l'oggetto

    public RectTransform interactionHint;           //Posizine UI
    [SerializeField] Vector2 interactionHintOffset;
    public Transform objectTransform;               //Posizione dell'oggetto a terra
    public Transform playerPosition;                //Posizione del player
    public Transform playerItem;                    //Posizione dell'item che tiene il player

    // Start is called before the first frame update
    void Start()
    {
        playerItem.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        interactionHint.gameObject.SetActive(false);

        if ((objectTransform.gameObject.activeInHierarchy) && (Vector3.Distance(playerPosition.position, objectTransform.position) <= 1.75f)) {
            interactionHint.gameObject.SetActive(true);
            SetInteractionHintPosition(objectTransform.position);

            if (Input.GetButtonDown("PickUp Item")) {
                prendimi.prediOggetto(objectTransform.gameObject, playerItem.gameObject);
                interactionHint.gameObject.SetActive(false);
            }
        }
    }

    //Funzione utile per mostrare la UI in base alla visuale del giocatore
    public void SetInteractionHintPosition(Vector3 objectWorldPosition)
    {
        Vector2 relativeScreenPos = Camera.main.WorldToScreenPoint(objectWorldPosition);

        float distanceFromCamera = Mathf.Clamp(Vector3.Distance(Camera.main.transform.position, objectWorldPosition), 1, 3);

        interactionHint.localScale = new Vector2(1 / distanceFromCamera, 1 / distanceFromCamera);
        interactionHint.position = relativeScreenPos + interactionHintOffset / distanceFromCamera;
    }

}
