using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] DialogueObject[] dialogues;
    [SerializeField] bool playEveryTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UI_Controller.instance.AddDialogues(dialogues);

            if (!playEveryTime)
                Destroy(gameObject);
        }
    }
}
