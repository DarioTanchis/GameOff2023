using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] Transform playerStartingpositon;

    private void Awake()
    {
        GameObject []players = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject p in players)
        {
            if (p.TryGetComponent(out CharacterController cc))
            {
                cc.enabled = false;
                p.transform.position = transform.position;
                cc.enabled = true;
            }
        }
    }
}
