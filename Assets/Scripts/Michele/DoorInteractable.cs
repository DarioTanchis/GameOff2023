using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : Interactable
{
    
    [SerializeField] AudioSource suonoPorta;
    [SerializeField] Vector3 rotationAxis = Vector3.up;
    private bool open = false;
    float closedRotation;
    float openRotation;
    public bool inverted = false;
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
    public override void Interact(PlayerInteract player){
        open = !open;
        if (TryGetComponent<AudioSource>(out AudioSource suonoPorta)) //Controlla se ha l'audio :)
        {
            suonoPorta.Play(); //suono apertura porta
        }
        
        if (open)
        {
            elapsedTime = 0;
        }
        else
        {
            elapsedTime = openingTime;        
        }  
        base.Interact(player);
    }
}
