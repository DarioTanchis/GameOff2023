using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractable : PickInteractable
{
    // Does something, called when "interact" is pressed
    public override void Interact(PlayerInteract player){
        base.Interact(player);
        player.setHasKey(true); 
    }
}
