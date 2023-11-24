using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : Interactable
{
    [SerializeField] Vector3 rotationAxis = Vector3.up;
    private bool open = false;
    float closedRotation;
    float openRotation;
    public bool inverted = false;
    float speed = 5;
    int rot = 90;
    float elapsedTime = 0f;
    float openingTime = 0.5f;

    void Start(){
        closedRotation = transform.localEulerAngles.z;
        if (inverted){
            rot = -rot;
        }
        openRotation = closedRotation + rot;
    }

    void Update(){
        if (open){
            elapsedTime += Time.deltaTime;
        }
        else{
            elapsedTime -= Time.deltaTime;  
        }
        float percent = elapsedTime / openingTime;
            transform.localEulerAngles = Vector3.Lerp(rotationAxis.normalized * closedRotation, rotationAxis.normalized * openRotation, percent);
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
