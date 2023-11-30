using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : Interactable
{
    [SerializeField] Light[] lights;
    [SerializeField] bool turnedOn;
    [SerializeField] AudioSource switchSound;   //

    private void Start()
    {
        TurnOnOrOff();
    }

    public override void Interact(PlayerInteract player)
    {
        base.Interact(player);
        turnedOn = !turnedOn;
        TurnOnOrOff();
        switchSound.Play();
    }

    void TurnOnOrOff()
    {
        foreach (Light l in lights)
        {
            l.enabled = turnedOn;
           
        }
    }
}
