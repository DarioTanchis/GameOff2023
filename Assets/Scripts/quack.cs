using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quack : Interactable
{
    [SerializeField] AudioSource qua;
    public override void Interact(PlayerInteract player)
    {
        qua.Play();
        base.Interact(player);
    }
}
