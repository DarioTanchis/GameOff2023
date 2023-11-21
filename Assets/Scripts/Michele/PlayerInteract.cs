using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] float raycastDistance = 3f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && Physics.Raycast(camera.position, camera.forward, out RaycastHit hit, raycastDistance))
        {
            if (hit.collider.GetComponent<Interactable>()){
                hit.collider.GetComponent<Interactable>().Interact(GetComponent<PlayerController>());
            }
        } 
    }
}
