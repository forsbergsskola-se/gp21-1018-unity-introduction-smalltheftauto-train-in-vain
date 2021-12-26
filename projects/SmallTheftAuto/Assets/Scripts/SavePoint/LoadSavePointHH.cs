using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

// TODO: These scripts should not all have been here in this folder, I think
public class LoadSavePointHH : MonoBehaviour
{
    private static bool LoadOnStart;
    public void LoadSave()
    {
        Debug.Log("Loading save... HH");
        LoadOnStart = true;
        SavePointHH.NextId = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Start()
    {
        if (LoadOnStart)
        {
            Invoke("PlacePlayer", 1);
        }
    }

    void PlacePlayer()
    {
        StreamReader loader = new StreamReader("Save.txt");
        var playerHealth = FindObjectOfType<PlayerHealth>();
        var playerController = FindObjectOfType<PlayerController>();
        var player = GameObject.FindGameObjectWithTag("Player");
        
        // TODO FIX POSITION
        var savePointIdToFind = Int32.Parse(loader.ReadLine());
        var savePoints = FindObjectsOfType<SavePointHH>().ToList();
        var found = savePoints.Find(x => x.Id == savePointIdToFind);
        found.GetComponent<Transform>();
        player.transform.position = found.GetComponent<Transform>().position;
        
        playerHealth.TakeDamage(playerHealth.maxHealth - Int32.Parse(loader.ReadLine()));
        playerController.Score = Int32.Parse(loader.ReadLine());
        playerController.addMoney(Int32.Parse(loader.ReadLine()));
        loader.Close();
    }
}
