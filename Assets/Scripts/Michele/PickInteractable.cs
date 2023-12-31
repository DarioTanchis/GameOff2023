using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickInteractable : Interactable
{
    // Does something, called when "interact" is pressed
    public override void Interact(PlayerInteract player){
        base.Interact(player);
        Destroy(gameObject);
    }
}
