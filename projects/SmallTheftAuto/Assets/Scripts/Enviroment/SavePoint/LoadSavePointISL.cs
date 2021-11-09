using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSavePointISL : MonoBehaviour
{
    private static bool LoadOnStart;

    private void Start()
    {
        if (LoadOnStart)
        {
            Invoke(nameof(PlacePlayer), 1f);
        }
    }

    void PlacePlayer()
    {
        StreamReader saveLoader = new StreamReader("Save.txt");
        var playerHealth = FindObjectOfType<PlayerHealth>();
        var playerController = FindObjectOfType<PlayerController>();
        var player = GameObject.FindGameObjectWithTag("Player");
        
        var targetSavePointId = Int32.Parse(saveLoader.ReadLine());
        var savePoints = FindObjectsOfType<SavePointISL>().ToList();
        var found = savePoints.Find(x => x.id == targetSavePointId);
        player.transform.position = found.GetComponent<Transform>().position;

        playerHealth.TakeDamage(playerHealth.maxHealth - Int32.Parse(saveLoader.ReadLine()));
        playerController.Score = Int32.Parse(saveLoader.ReadLine());
        playerController.addMoney(Int32.Parse(saveLoader.ReadLine()));
        saveLoader.Close();
    }

    public void LoadSave()
    {
        Debug.Log("Loading save -- -- -- ");
        LoadOnStart = true;
        SavePointISL.nextId = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
