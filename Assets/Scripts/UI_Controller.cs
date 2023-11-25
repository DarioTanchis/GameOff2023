using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] RectTransform interactionHint;
    [SerializeField] Vector2 interactionHintOffset;
    public static UI_Controller instance;
    [SerializeField] TMPro.TextMeshProUGUI dialogueText;
    List<DialogueObject> dialogues = new List<DialogueObject>();
    bool dialogueCoroutineRunning = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this);
        }

        interactionHint.gameObject.SetActive(false);
        dialogueText.text = "";
    }

    public void SetInteractionHintPosition(Vector3 objectWorldPosition)
    {
        Vector2 relativeScreenPos = Camera.main.WorldToScreenPoint(objectWorldPosition);
       
        float distanceFromCamera = Mathf.Clamp(Vector3.Distance(Camera.main.transform.position, objectWorldPosition), 1, 3);

        interactionHint.localScale = new Vector2(1 / distanceFromCamera, 1 / distanceFromCamera);
        interactionHint.position = relativeScreenPos + interactionHintOffset / distanceFromCamera;
    }

    public void EnableInteractionHint(bool enable)
    {
        interactionHint.gameObject.SetActive(enable);
    }

    public void AddDialogue(DialogueObject dialogue)
    {
        dialogues.Add(dialogue);

        if (!dialogueCoroutineRunning)
        {
            StartCoroutine(DisplayDialogues());
        }
    }

    public void AddDialogues(DialogueObject []dialogues)
    {
        this.dialogues.AddRange(dialogues);

        if (!dialogueCoroutineRunning)
        {
            StartCoroutine(DisplayDialogues());
        }
    }

    IEnumerator DisplayDialogues()
    {
        dialogueCoroutineRunning = true;

        foreach(DialogueObject d in dialogues)
        {
            while(Time.timeScale == 0)
            {
                yield return null;
            }

            dialogueText.text = d.text;

            float endDialogueTime = Time.time;
            while(Time.time - endDialogueTime < d.timeToNextLine)
            {
                yield return null;
            }
        }

        dialogueText.text = "";
        dialogues.Clear();

        dialogueCoroutineRunning = false;
    }
}

[System.Serializable]
public class DialogueObject
{
    public string text;
    public float timeToNextLine;
}