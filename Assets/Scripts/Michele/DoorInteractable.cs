using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : Interactable
{
    
    [SerializeField] AudioSource suonoPorta;
    [SerializeField] AudioClip lockedSound = null;
    [SerializeField] Vector3 rotationAxis = Vector3.up;
    [SerializeField] bool locked = false;
    AudioClip sp;
    private bool open = false;
    float closedRotation;
    float openRotation;
    public bool inverted = false;
    int rot = 90;
    float elapsedTime = 0f;
    float openingTime = 0.5f;

    void Start(){
        if (TryGetComponent<AudioSource>(out AudioSource audioSource) && locked) //Controlla se ha l'audio :)
        {
            sp = suonoPorta.clip;
        }
        
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
        base.Interact(player);
        if (TryGetComponent<AudioSource>(out AudioSource audioSource) && locked) //Controlla se ha l'audio :)
        {
                audioSource.clip = lockedSound;
                audioSource.Play(); //suono porta lockata
        }
        if (locked && !player.getHasKey()){
            List<DialogueObject> dialogues = new List<DialogueObject>();
            DialogueObject d = new DialogueObject();
            d.text = "Locked";
            d.timeToNextLine = 2;
            dialogues.Add(d);
            UI_Controller.instance.AddDialogues(dialogues.ToArray());
        }
        else if (locked && player.getHasKey()){
            
            locked = false;
            player.setHasKey(false);
        }
        if (!locked){
            if (TryGetComponent<AudioSource>(out AudioSource audioSource1)) //Controlla se ha l'audio :)
            {
                audioSource1.clip = sp;
                audioSource1.Play(); //suono apertura porta
            }
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
}
