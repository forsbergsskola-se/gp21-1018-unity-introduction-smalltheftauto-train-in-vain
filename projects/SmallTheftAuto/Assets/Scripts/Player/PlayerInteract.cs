using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public List<GameObject> Interactables;
    public float InteractRange = 5f;
    
    private const KeyCode InteractKey = KeyCode.F;
    private GameObject ClosestInteractable;

    private float closestRange;


    private void Update()
    {
        if (gameObject.activeInHierarchy && InteractableInRange() && Input.GetKeyDown(InteractKey))
        {
            ClosestInteractable.GetComponent<IInteractable>().Interact(gameObject);
        }
    }


    bool InteractableInRange()
    {
        ClosestInteractable = null;
        closestRange = InteractRange;
        foreach (var interactable in Interactables)
        {
            if (interactable == null)
            {
                Interactables.Remove(interactable);
                Debug.Log("Found a destroyed object in the list and removed it.");
                break;
            }
            float distance = Vector3.Distance(gameObject.transform.position, interactable.gameObject.transform.position);
            if (distance <= InteractRange && distance < closestRange)
            {
                ClosestInteractable = interactable;
            }
        }
        return ClosestInteractable != null;
    }
}
