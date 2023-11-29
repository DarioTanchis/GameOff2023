using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsInteraction : Interactable
{
    [SerializeField] StairsController stairsController;

    public override void Interact(PlayerInteract player)
    {
        stairsController.openStairs(true);
    }
}
