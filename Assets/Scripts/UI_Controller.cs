using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] RectTransform interactionHint;
    [SerializeField] Vector2 interactionHintOffset;
    public static UI_Controller instance;

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
}
