using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteractable : PickInteractable
{
    [SerializeField] AudioClip pickUpKey;
    // Does something, called when "interact" is pressed
    public override void Interact(PlayerInteract player){
        AudioSource.PlayClipAtPoint(pickUpKey, new Vector3(5, 1, 4.5f));
        base.Interact(player);
        player.setHasKey(true); 
    }
}
