using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractable : Interactable
{
    // Does something, called when "interact" is pressed
    public override void Interact(PlayerInteract player){
        player.setHasKey(true);
        base.Interact(player);
    }
}
