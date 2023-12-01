using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] float raycastDistance = 3f;
    bool hasKey = false;
    bool wasPointingAtInteractable;
    public bool hasStairThing = false;

    // Update is called once per frame
    void Update()
    {
        if (wasPointingAtInteractable)
        {
            wasPointingAtInteractable = false;
            UI_Controller.instance?.EnableInteractionHint(false);
        }

        if (Physics.Raycast(camera.position, camera.forward, out RaycastHit hit, raycastDistance) && hit.collider.TryGetComponent(out Interactable interactable))
        {
            UI_Controller.instance?.EnableInteractionHint(true);
            UI_Controller.instance?.SetInteractionHintPosition(hit.point);

            if (Input.GetButtonDown("Interact")){
                interactable.Interact(this);
            }

            wasPointingAtInteractable = true;
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
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(camera.position, camera.forward);
    }
}
