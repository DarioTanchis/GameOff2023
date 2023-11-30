using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Interactable : MonoBehaviour
{
    // Does something, called when "interact" is pressed
    public virtual void Interact(PlayerInteract player){
        if(GameObject.Find("GameManager")){
            if(GameObject.Find("GameManager").TryGetComponent<InitialTasks>(out InitialTasks it)){
                it.ItemInteracted(this.gameObject);
            }
        }
    }
}
