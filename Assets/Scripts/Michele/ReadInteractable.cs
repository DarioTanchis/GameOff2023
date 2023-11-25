using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInteractable : Interactable
{
    [SerializeField] List<string> phrases;

    // Does something, called when "interact" is pressed
    public override void Interact(PlayerInteract player){
        List<DialogueObject> dialogues = new List<DialogueObject>();

        foreach(string phrase in phrases){
            DialogueObject d = new DialogueObject();
            d.text = phrase;
            d.timeToNextLine = 3;
            dialogues.Add(d);
        }
        
        UI_Controller.instance.AddDialogues(dialogues.ToArray());
    }
}
