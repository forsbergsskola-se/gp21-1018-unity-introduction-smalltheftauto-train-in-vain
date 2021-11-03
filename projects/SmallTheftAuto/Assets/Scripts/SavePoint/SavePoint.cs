using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SavePoint : MonoBehaviour, IInteractable
{
    private static bool TurnYellow;

    public static int NextId;
    public int Id;

    private PlayerController player;
    private PlayerHealth playerHealth;
    
    private void Start()
    {
        FindObjectOfType<PlayerInteract>().Interactables.Add(gameObject);
        Id = NextId;
        NextId++;
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
        StreamWriter save = new StreamWriter("Save.txt");
        save.WriteLine(Id);
        save.WriteLine(playerHealth.currentHealth);
        save.WriteLine(player.Score);
        save.WriteLine(player.Money);
        save.Close();
    }
}
