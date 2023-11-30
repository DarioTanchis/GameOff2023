using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : Interactable
{
    [SerializeField] Light[] lights;
    [SerializeField] bool turnedOn;

    private void Start()
    {
        TurnOnOrOff();
    }

    public override void Interact(PlayerInteract player)
    {
        base.Interact(player);
        turnedOn = !turnedOn;
        TurnOnOrOff();
    }

    void TurnOnOrOff()
    {
        foreach (Light l in lights)
        {
            l.enabled = turnedOn;
        }
    }
}
