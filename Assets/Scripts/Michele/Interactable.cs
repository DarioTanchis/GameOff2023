using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Interactable : MonoBehaviour
{
    // Does something, called when "interact" is pressed
    public virtual void Interact(PlayerInteract player){

    }
}
