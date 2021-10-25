using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject phoneBox;
    public GameObject phoneBox2;
    public GameObject questOne;
    void Start()
    {
        Instantiate(player);
        var placedPhoneBox = Instantiate(phoneBox);
        placedPhoneBox.transform.position=new Vector3(-0.519f, 41.2f,0f);
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

    void Update()
    {
        //
    }
}
