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
                if (grabbed)
                {
                    grabbed.transform.parent = null;
                    grabbedRigidbody.isKinematic = false;
                    grabbedRigidbody.useGravity = true;
                    grabbedRigidbody.AddForce(transform.right * throwForce / 5);
                }

                grabbed = hit.collider.gameObject;
                grabbed.transform.parent = grabPosition;
                grabbed.transform.localRotation = Quaternion.identity;
                grabbed.transform.localPosition = Vector3.zero;

                grabbedRigidbody = grabbed.GetComponent<Rigidbody>();
                grabbedRigidbody.isKinematic = true;
                grabbedRigidbody.useGravity = false;

                Debug.Log("Grabbed " + grabbed);

                if(GameObject.Find("GameManager")){
                    if(GameObject.Find("GameManager").TryGetComponent<InitialTasks>(out InitialTasks it)){
                        it.ItemGrabbed(grabbed);
                    }
                }
            }
        }
        else if(hintEnabled)
        {
            UI_Controller.instance.EnableInteractionHint(false);
            hintEnabled = false;
        }

        if (Input.GetButtonDown("Fire1") && grabbed && grabbed.name != "Pole")
        {
            grabbed.transform.parent = null;
            grabbedRigidbody.isKinematic = false;
            grabbedRigidbody.useGravity = true;
            grabbedRigidbody.AddForce(camera.forward * throwForce);
            grabbedRigidbody = null;
            grabbed = null;

        }
    }

    public void RemoveGrabbed()
    {
        Destroy(grabbed);
        grabbed = null;
        grabbedRigidbody = null;
    }
}
