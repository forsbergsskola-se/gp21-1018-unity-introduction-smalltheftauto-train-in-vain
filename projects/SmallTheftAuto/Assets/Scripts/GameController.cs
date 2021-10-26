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

    public GameObject Pistol; 
    private GameObject pistol;
    void Start()
    {
        Player = Instantiate(playerPrefab);
        var placedPhoneBox = Instantiate(phoneBox);
        placedPhoneBox.transform.position=new Vector3(-0.519f, 41.2f,0f);
        var questMenuController = placedPhoneBox.GetComponent<QuestMenuController>();
        questMenuController.QuestTitle = "CarRace";
        questMenuController.QuestDescription = "Complete the race course in time for a reward.";
        questMenuController.quest = questOne;

        pistol = Instantiate(Pistol);
        pistol.transform.position = new Vector3(-2.278244f, 5f, 0f);

        // var placedPhoneBox2 = Instantiate(phoneBox2);
        // placedPhoneBox2.transform.position=new Vector3(-0.519f, 21.2f,0f);
        // var questMenuController2 = placedPhoneBox2.GetComponent<QuestMenuController>();
        // questMenuController2.QuestTitle = "BikeRace";
        // questMenuController2.QuestDescription = "Bike go ded.";
        // questMenuController2.quest = questOne;
    }
}
