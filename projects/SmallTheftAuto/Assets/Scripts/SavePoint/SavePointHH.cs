using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class SavePointHH : MonoBehaviour, IInteractable
{
    public static int NextId;
    public int Id;
    private PlayerController player;
    private static bool TurnYellow;
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
        StreamWriter saveGame = new StreamWriter("Save.txt");
        saveGame.WriteLine(Id);
        saveGame.WriteLine(playerHealth.currentHealth);
        saveGame.WriteLine(player.Score);
        saveGame.WriteLine(player.Money);
        saveGame.Close();
    }
}
