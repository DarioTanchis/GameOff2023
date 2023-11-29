using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerInteractable : Interactable
{
    [SerializeField] AudioClip openSuono;
    [SerializeField] AudioClip closeSuono;
    [SerializeField] Vector3 openPosition;
    [SerializeField] GameObject handle = null;
    [SerializeField] bool locked = false;
    Vector3 closedPosition;
    Vector3 handlePosition;
    private bool open = false;
    float openingTime = 0.5f;
    float elapsedTime = 0;

    void Start(){
        closedPosition = transform.position;
        openPosition = transform.TransformPoint(openPosition);
        if (handle != null){
            handlePosition = handle.transform.position;
        }
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
        if (handle != null){
            handle.transform.position = Vector3.Lerp(handlePosition, openPosition, percentComplete);
        }
    }

    // Does something, called when "interact" is pressed
    public override void Interact(PlayerInteract player){
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
            open = !open;
            if (open){
                AudioSource.PlayClipAtPoint(openSuono, transform.position);
                elapsedTime = 0;
            }
            else{
                AudioSource.PlayClipAtPoint(closeSuono, transform.position);
                elapsedTime = openingTime;        
            }     
        }
        base.Interact(player);
    }
}
