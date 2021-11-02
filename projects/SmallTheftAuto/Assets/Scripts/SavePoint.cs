using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour, IInteractable
{
    // static bool 
    private void Start()
    {
        FindObjectOfType<PlayerInteract>().Interactables.Add(gameObject);
    }

    public void Interact(GameObject User)
    {
        GetComponent<SpriteRenderer>().color = Color.green;
    }
}
