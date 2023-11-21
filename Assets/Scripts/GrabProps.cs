using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabProps : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] float raycastDistance = 3f;
    [SerializeField] Transform grabPosition;
    GameObject grabbed;
    Rigidbody grabbedRigidbody;
    [SerializeField] float throwForce = 20;
    bool hintEnabled;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(camera.position, camera.forward, out RaycastHit hit, raycastDistance) && hit.collider.CompareTag("Prop"))
        {
            UI_Controller.instance.EnableInteractionHint(true);
            UI_Controller.instance.SetInteractionHintPosition(hit.point);
            hintEnabled = true;

            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log("Grabbed prop");

                if (grabbed)
                {
                    grabbed.transform.parent = null;
                    grabbedRigidbody.isKinematic = false;
                    grabbedRigidbody.useGravity = true;
                    grabbedRigidbody.AddForce(transform.right * throwForce / 5);
                }

                grabbed = hit.collider.gameObject;
                grabbed.transform.parent = grabPosition;
                grabbed.transform.localPosition = Vector3.zero;

                grabbedRigidbody = grabbed.GetComponent<Rigidbody>();
                grabbedRigidbody.isKinematic = true;
                grabbedRigidbody.useGravity = false;
            }
        }
        else if(hintEnabled)
        {
            UI_Controller.instance.EnableInteractionHint(false);
            hintEnabled = false;
        }

        if (Input.GetButtonDown("Fire1") && grabbed)
        {
            grabbed.transform.parent = null;
            grabbedRigidbody.isKinematic = false;
            grabbedRigidbody.useGravity = true;
            grabbedRigidbody.AddForce(camera.forward * throwForce);
            grabbedRigidbody = null;
            grabbed = null;

        }
    }
}
