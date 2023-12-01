using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFallingOver : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody objectRb;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        objectRb = this.gameObject.GetComponent<Rigidbody>();
        direction = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    private void FixedUpdate()
    {
        objectRb.AddForce(direction * speed);
        //StartCoroutine(LittleUmph());
        //StopCoroutine(LittleUmph());
    }

    private IEnumerator LittleUmph()
    {
        //transform.Translate(Vector3.forward * speed *  Time.deltaTime);
        //objectRb.velocity = Vector3.zero;

        objectRb.AddForce(direction * speed);
        yield return new WaitForSeconds(1);
        
        //objectRb.velocity = Vector3.zero;
    }
}
