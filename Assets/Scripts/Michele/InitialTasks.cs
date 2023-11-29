using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InitialTasks : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] List<GameObject> toGrab;
    UI_Controller ui;
    int taskIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        ui = UI_Controller.instance;
        Advance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDialogue(string phrase, int time)
    {
        List<DialogueObject> dialogues = new List<DialogueObject>();

        /*foreach (string phrase in phrases){
            DialogueObject d = new DialogueObject();
            d.text = phrase;
            d.timeToNextLine = time;
            dialogues.Add(d);
        }*/
        DialogueObject d = new DialogueObject();
        d.text = phrase;
        d.timeToNextLine = time;
        dialogues.Add(d);

        ui.AddDialogues(dialogues.ToArray());
    }

    public void ItemGrabbed(GameObject obj){
        if(toGrab.Contains(obj)){
            toGrab.Remove(obj);
        }
        if(toGrab.Count <= 0){
            Advance();
        }
    }

    void Advance(){
        taskIndex++;
        switch (taskIndex){
            case 1: Task1();
            break;
            case 2: Task2();
            break;
        }
    }

    void Task1(){
        string task = "Mom: withdraw the dishes from the table";
        textMesh.text = "Withdraw the dishes";
        setDialogue(task, 5);
    }

    void Task2(){
        string task = "Mom: Pull out the chicken from the fridge";
        textMesh.text = "Take the chicken from the fridge";
        setDialogue(task, 5);
    }
}
