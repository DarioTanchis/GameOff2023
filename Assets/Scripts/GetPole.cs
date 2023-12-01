using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPole : Interactable
{
    public override void Interact(PlayerInteract player)
    {
        player.hasStairThing = true;
    }
}
