using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SavePointID : MonoBehaviour, IInteractable
{
    private static bool TurnYellow;

    public static int NextID;
    public int Id;

    private PlayerHealth playerHealth;
    private PlayerController player;
    private void Start()
    {
        FindObjectOfType<PlayerInteract>().Interactables.Add(gameObject);
        Id = NextID;
        NextID++;
        player = FindObjectOfType<PlayerController>();
        playerHealth = FindObjectOfType<PlayerHealth>();
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
        StreamWriter save = new StreamWriter("Save.txt");
        save.WriteLine(Id);
        save.WriteLine(playerHealth.currentHealth);
        save.WriteLine(player.Score);
        save.WriteLine(player.Money);
        save.Close();
    }
}
