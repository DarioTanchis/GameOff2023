using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using UnityEngine;
using UnityEngine.Rendering;

public class CameraDiSandro : MonoBehaviour
{
    public Transform sandro;
    public float cameraSpeed = 5;

    public float sensibilitÓMouse = 100f;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = sandro.position; //Serve per ricavarci la distanza
        Cursor.lockState = CursorLockMode.Locked; 
    }

    // LateUpdate viene chiamato dopo che tutti gli update sono finiti
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilitÓMouse * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilitÓMouse * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        sandro.Rotate(Vector3.up * mouseX);
        //transform.position = Vector3.Slerp(transform.position, distance + sandro.position, Time.deltaTime * cameraSpeed); //Si avvicina lentamente alla posizione di sandro, rende tutto pi¨ piacevole alla vista
    }

}
