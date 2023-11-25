using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInteractable : Interactable
{
    [SerializeField] List<DialogueObject> phrases;

    // Does something, called when "interact" is pressed
    public override void Interact(PlayerInteract player){
        UI_Controller.instance.AddDialogues(phrases.ToArray());
    }
}
