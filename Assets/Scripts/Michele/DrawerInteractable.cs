using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerInteractable : Interactable
{
    [SerializeField] Vector3 openPosition;
    [SerializeField] GameObject handle = null;
    Vector3 closedPosition;
    Vector3 handlePosition;
    private bool open = false;
    float openingTime = 0.5f;
    float elapsedTime = 0;

    void Start(){
        closedPosition = transform.position;
        openPosition = transform.TransformPoint(openPosition);
        handlePosition = handle.transform.position;
    }

    void Update(){
        if (open){
            elapsedTime += Time.deltaTime;         
        }
        else if (elapsedTime >= 0){
            elapsedTime -= Time.deltaTime;
        }
        float percentComplete = elapsedTime / openingTime;
        transform.position = Vector3.Lerp(closedPosition, openPosition, percentComplete);
        handle.transform.position = Vector3.Lerp(handlePosition, openPosition, percentComplete);
    }

    // Does something, called when "interact" is pressed
    public override void Interact(PlayerController player){
        open = !open;
        if (open)
        {
            elapsedTime = 0;
        }
        else
        {
            elapsedTime = openingTime;        
        }     
    }
}
