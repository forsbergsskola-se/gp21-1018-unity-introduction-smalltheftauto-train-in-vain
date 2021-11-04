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

    public GameObject Pistol; 
    private GameObject pistol;
    [SerializeField] private GameObject MachineGun;
    private GameObject machineGun;
    private PlayerInteract playerInteract;

    private void Awake()
    {
        pistol = Instantiate(Pistol);
        pistol.transform.position = new Vector3(-2.25f, 5f, 0f);
        
        machineGun = Instantiate(MachineGun, new Vector3(-4.85f, 5f, 0f), Quaternion.identity);
    }

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
        
        var placedPhoneBox = Instantiate(phoneBox);
        placedPhoneBox.transform.position=new Vector3(-0.519f, 41.2f,0f);
        playerInteract.Interactables.Add(placedPhoneBox);

        Instantiate(pizza).transform.position = new Vector3(30, 5, 0);
        Instantiate(burger).transform.position = new Vector3(30, 0, 0);
        
        Instantiate(savePointPrefab).transform.position = new Vector3(10, 28, 0);
        Instantiate(savePointPrefab).transform.position = new Vector3(-10, 28, 0);

        Instantiate(buildingPrefab).transform.position = new Vector3(10, 10, 0);
        
        
        
        var questMenuController = placedPhoneBox.GetComponent<QuestMenuController>();
        questMenuController.QuestTitle = "CarRace";
        questMenuController.QuestDescription = "Complete the race course in time for a reward.";
        questMenuController.quest = questOne;

        // var placedPhoneBox2 = Instantiate(phoneBox2);
        // placedPhoneBox2.transform.position=new Vector3(-0.519f, 21.2f,0f);
        // var questMenuController2 = placedPhoneBox2.GetComponent<QuestMenuController>();
        // questMenuController2.QuestTitle = "BikeRace";
        // questMenuController2.QuestDescription = "Bike go ded.";
        // questMenuController2.quest = questOne;
    }
}
