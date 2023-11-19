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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && Physics.Raycast(camera.position, camera.forward, out RaycastHit hit, raycastDistance) && hit.collider.CompareTag("Prop"))
        {
            Debug.Log("Grabbed prop");

            if (grabbed)
            {
                grabbed.transform.parent = null;
            }

            grabbed = hit.collider.gameObject;
            grabbed.transform.parent = grabPosition;
            grabbed.transform.localPosition = Vector3.zero;

            grabbedRigidbody = grabbed.GetComponent<Rigidbody>();
            grabbedRigidbody.isKinematic = true;
            grabbedRigidbody.useGravity = false;
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
