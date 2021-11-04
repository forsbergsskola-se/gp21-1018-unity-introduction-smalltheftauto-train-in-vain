using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject playerPrefab;

    // This should be accessed instead of player directly in cases where the player might be inactive in a car/phonebox.
    public GameObject Player
    {
        get;
        private set;
    }
    
    public GameObject phoneBox;
    public GameObject phoneBox2;
    public GameObject questOne;
    public GameObject pizza;
    public GameObject burger;
    
    public GameObject savePointPrefab;
    public GameObject buildingPrefab;

    [SerializeField] private GameObject Pistol;
    [SerializeField] private GameObject MachineGun;
    private PlayerInteract playerInteract;

    void Start()
    {
        
        SavePoint.NextId = 0;
        
        Player = Instantiate(playerPrefab);
        playerInteract = Player.GetComponent<PlayerInteract>();
        FindObjectOfType<CarRaceController>().player = Player;
        var moneyOnDeath = PlayerController.MoneyOnDeath;
        var scoreOnDeath = PlayerController.ScoreOnDeath;
        if (moneyOnDeath!=0|| scoreOnDeath!=0)
        {
            FindObjectOfType<PlayerController>().addMoney(moneyOnDeath/2);
            FindObjectOfType<PlayerController>().Score = scoreOnDeath;
            PlayerController.MoneyOnDeath = 0;
            PlayerController.ScoreOnDeath = 0;
        }
        
        Instantiate(Pistol, new Vector3(-2.25f, 5f, 0f), Quaternion.identity);
        Instantiate(MachineGun, new Vector3(-5.85f, 5f, 0f), Quaternion.identity);
        
        var placedPhoneBox = Instantiate(phoneBox, new Vector3(-0.519f, 41.2f,0f), Quaternion.identity);
        playerInteract.Interactables.Add(placedPhoneBox);

        Instantiate(pizza, new Vector3(30, 5, 0), Quaternion.identity);
        Instantiate(burger, new Vector3(30, 0, 0), Quaternion.identity);
        
        Instantiate(savePointPrefab, new Vector3(10, 28, 0), Quaternion.identity);
        Instantiate(savePointPrefab, new Vector3(-10, 28, 0), Quaternion.identity);
        Instantiate(buildingPrefab, new Vector3(10, 10, 0), Quaternion.identity);

        var questMenuController = placedPhoneBox.GetComponent<QuestMenuController>();
        questMenuController.QuestTitle = "CarRace";
        questMenuController.QuestDescription = "Complete the race course in time for a reward.";
        questMenuController.quest = questOne;
    }

    public void AddMoney(int value)
    {
        Player.GetComponent<PlayerController>().addMoney(value);
    }

    public void AddScore(int value)
    {
        Player.GetComponent<PlayerController>().Score += value;
    }
}
