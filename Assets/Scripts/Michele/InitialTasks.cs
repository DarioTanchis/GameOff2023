using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InitialTasks : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] List<GameObject> toGrab;
    List<GameObject> toInteract = new List<GameObject>();
    bool expectsInteraction = false;
    bool expectsGrab = false;
    UI_Controller ui;
    int taskIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        ui = UI_Controller.instance;
        Advance();
    }

    void setDialogue(string phrase, int time)
    {
        List<DialogueObject> dialogues = new List<DialogueObject>();

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
        if(toGrab.Count <= 0 && expectsGrab){
            Advance();
        }
    }

    public void ItemInteracted(GameObject obj){
        if(toInteract.Contains(obj)){
            toInteract.Remove(obj);
        }
        if(toInteract.Count <= 0 && expectsInteraction){
            Advance();
        }
    }

    void Advance(){
        ClearTasks();
        taskIndex++;
        switch (taskIndex){
            case 1: Task1();
            break;
            case 2: Task2();
            break;
            case 3: Task3();
            break;
            default: ClearTasks();
            break;
        }

        foreach(GameObject g in toInteract) {
            Debug.Log("To interact: " + g.ToString());
        }
        foreach(GameObject g in toGrab) {
            Debug.Log("To grab: " + g.ToString());
        }
    }

    void Task1(){
        string task = "Mom: Turn off the light in my room";
        textMesh.text = "Turn off the light in mom's room";
        setDialogue(task, 5);
        toInteract.Clear();
        toInteract.Add(GameObject.Find("/Casa Base/Stanza michele/Lightswitch"));
        expectsInteraction = true;
    }

    void Task2(){
        if(toGrab.Count <= 0 && expectsGrab){
            Advance();
        }
        else{
            string task = "Mom: Clear the table in the kitchen";
            textMesh.text = "Clear the table";
            setDialogue(task, 5);
            expectsGrab = true;
        }
    }

    void Task3(){
        if(GameObject.Find("/Casa Base/Bathroom/Key")){
            string task = "Mom: Take the key I left in the bathroom";
            textMesh.text = "Take the key in the bathroom";
            setDialogue(task, 5);
            toInteract.Clear();
            toInteract.Add(GameObject.Find("/Casa Base/Bathroom/Key"));
            expectsInteraction = true;
        }
        else{
            Advance();
        }
    }

    void ClearTasks(){
        textMesh.text = "";
        expectsInteraction = false;
        expectsGrab = false;
    }
}
