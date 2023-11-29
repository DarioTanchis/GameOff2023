using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHintAnimation : MonoBehaviour
{
    [SerializeField] float switchTime = .2f;
    [SerializeField] GameObject[] gameObjects;
    float lastSwitchTime;
    bool active;

    // Start is called before the first frame update
    void Start()
    {
        gameObjects[0].SetActive(active);
        gameObjects[1].SetActive(!active);
        lastSwitchTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastSwitchTime > switchTime)
        {
            //Debug.Log("Switch");
            gameObjects[0].SetActive(active);
            gameObjects[1].SetActive(!active);
            lastSwitchTime = Time.time;
            active = !active;
        }
    }
}
