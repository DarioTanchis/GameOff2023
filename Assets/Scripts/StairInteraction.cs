using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairInteraction : Interactable
{
    [SerializeField] StairsController stairController;
    [SerializeField] BoxCollider boxCollider;

    public override void Interact(PlayerInteract player)
    {
        if (player.hasStairThing)
        {
            stairController.openStairs(true);
            player.hasStairThing = false;
            boxCollider.enabled = false;
            Destroy(this);
        }
        else
        {
            DialogueObject d = new DialogueObject();
            d.text = "I can't reach it";
            d.timeToNextLine = 3;

            UI_Controller.instance.AddDialogue(d);
        }
    }
}
