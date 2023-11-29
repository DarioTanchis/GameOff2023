using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SANDRO : MonoBehaviour
{

    public CharacterController cc; 
    private bool groundedPlayer = false;
    public int playerSpeed = 3; //metri al secondo percorsi da sandro
    public float jumpHeight = 1.0f;
    public float gravityValue = -9f;
    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = cc.isGrounded; //variavile che controlla se sandro è a terra

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Vector3 move = new Vector3(x, 0, z); //Inizializzazione vettore che gestirà i movimenti di sandro, (x, y, z), utile per i tps

        Vector3 move = transform.right * x + transform.forward * z; //Sandro si sposta verso la posizione che punta la camera, utile per gli fps 

        move.y = 0; //Ignora l'inclinazione verticale della camera
        move = move.normalized; //In questo modo la somma dei componenti del vettore ha valore 1 :), risolve anche problemi di velocità quando si va disbiecco

        /* 
        //Se move non è zero allora sandro rimane girato nella direzione in cui si stava muovendo, utile per i tps  
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
        */

        //Fa saltare sandro
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            move.y = jumpHeight;
        }
        else
        {
            move.y += gravityValue; //Forza di gravità :)
        }

        cc.Move(move * Time.deltaTime * playerSpeed); //Time.deltaTime è il tempo passato dall'ultimo frame, serve per muovere del tanto giusto sandro, in m/s

    }
}
