using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] float raycastDistance = 3f;
    bool hasKey = false;

    // Update is called once per frame
    void Update()
    {
        UI_Controller.instance?.EnableInteractionHint(false);
        if (Physics.Raycast(camera.position, camera.forward, out RaycastHit hit, raycastDistance) && hit.collider.TryGetComponent(out Interactable interactable))
        {
            UI_Controller.instance?.EnableInteractionHint(true);
            UI_Controller.instance?.SetInteractionHintPosition(hit.point);

            if (Input.GetButtonDown("Interact")){
                interactable.Interact(this);
            }
        }
    }

    public bool getHasKey()
    {
        return hasKey;
    }

    public void setHasKey(bool v)
    {
        hasKey = v;
    }
}
