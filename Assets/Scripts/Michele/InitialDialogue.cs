using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDialogue : MonoBehaviour
{
    [SerializeField] List<DialogueObject> initDialogue;
    // Start is called before the first frame update
    void Start()
    {
        sendDialogue(initDialogue);
    }

    void sendDialogue(List<DialogueObject> dialogue){
        UI_Controller.instance.AddDialogues(dialogue.ToArray());
    }
}

