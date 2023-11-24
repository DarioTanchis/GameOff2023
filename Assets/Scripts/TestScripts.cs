using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestScripts : MonoBehaviour
{
    void Start()
    {
        //TestDialogue();
    }

    void TestDialogue()
    {
        List<DialogueObject> dialogues = new List<DialogueObject>();

        DialogueObject d = new DialogueObject();
        d.text = "Dialogo 1";
        d.timeToNextLine = 5;

        dialogues.Add(d);

        DialogueObject d2 = new DialogueObject();
        d2.text = "Dialogo 2";
        d2.timeToNextLine = 5;

        dialogues.Add(d2);

        UI_Controller.instance.AddDialogues(dialogues.ToArray());
    }
}
