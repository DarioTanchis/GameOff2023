using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] CharacterController cc;
    [SerializeField] float gravity = 9.8f;
    [SerializeField] float speed = 5;
    [SerializeField] float mouseSpeed = 5;
    [SerializeField] float maxMouseRot = 50;
    [SerializeField] float minMouseRot = -50;
    Vector2 mouseRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = ((new Vector3(transform.forward.x, 0, transform.forward.z) * Input.GetAxis("Vertical")).normalized + (transform.right * Input.GetAxis("Horizontal")).normalized).normalized * speed;

        cc.Move((movement + Vector3.down * gravity) * Time.smoothDeltaTime);

        mouseRotation.x += Input.GetAxis("Mouse X") * Time.smoothDeltaTime * mouseSpeed;
        mouseRotation.y += Input.GetAxis("Mouse Y") * Time.smoothDeltaTime * mouseSpeed;
        mouseRotation.y = Mathf.Clamp(mouseRotation.y, minMouseRot, maxMouseRot);


        transform.rotation = Quaternion.Euler(new Vector3(0, mouseRotation.x));
        camera.localRotation = Quaternion.Euler(new Vector3(-mouseRotation.y, 0));
    }
}
