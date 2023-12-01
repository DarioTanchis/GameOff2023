using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int currentSceneIndex = 0;
    [SerializeField] DialogueObject[] startingDialogues;
    public static GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        UI_Controller.instance.AddDialogues(startingDialogues);
    }
}
