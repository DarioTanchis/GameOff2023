using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityInvert : MonoBehaviour
{
    [SerializeField] bool inverted = true;

    // Start is called before the first frame update
    void Start()
    {
        if(inverted)
            Physics.gravity = new Vector3(0, 9.8f, 0);
        else
            Physics.gravity = new Vector3(0,-9.8f, 0);
    }
}
