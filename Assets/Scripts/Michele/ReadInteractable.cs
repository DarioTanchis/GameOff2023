using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReadInteractable : Interactable
{
    [SerializeField] List<DialogueObject> phrases;
    public UnityEvent interacted;

    // Does something, called when "interact" is pressed
    public override void Interact(PlayerInteract player){
        UI_Controller.instance.AddDialogues(phrases.ToArray());
        interacted.Invoke();
    }
}
