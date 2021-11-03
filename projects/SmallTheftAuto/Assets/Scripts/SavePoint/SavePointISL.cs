using System.IO;
using UnityEngine;

public class SavePointISL : MonoBehaviour, IInteractable
{
    private static bool TurnYellow;

    internal static int nextId;
    internal int id;

    private PlayerHealth player;
    private PlayerController playerControll;

    private void Start()
    {
        id = nextId;
        nextId++;
        FindObjectOfType<PlayerInteract>().Interactables.Add(gameObject);
        player = FindObjectOfType<PlayerHealth>();
        playerControll = FindObjectOfType<PlayerController>();
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
        StreamWriter saveWriter = new StreamWriter("Save.txt");
        saveWriter.WriteLine(id);
        saveWriter.WriteLine(player.currentHealth);
        saveWriter.WriteLine(playerControll.Score);
        saveWriter.WriteLine(playerControll.Money);
        saveWriter.Close();
    }
}
