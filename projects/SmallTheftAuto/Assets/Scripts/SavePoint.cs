using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour, IInteractable
{
    private static bool TurnYellow;
    
    private void Start()
    {
        FindObjectOfType<PlayerInteract>().Interactables.Add(gameObject);
    }

    private void Update()
    {
        if (TurnYellow)
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }

    public void Interact(GameObject User)
    {
        TurnYellow = true;
        Invoke("MakeGreen", 0.25f);
    }

    void MakeGreen()
    {
        TurnYellow = false;
        GetComponent<SpriteRenderer>().color = Color.green;
        Save();
    }

    void Save()
    {
        // TODO: ADD SAVE CODE HERE! -----------------------------------------------------------------------------------
    }
}
