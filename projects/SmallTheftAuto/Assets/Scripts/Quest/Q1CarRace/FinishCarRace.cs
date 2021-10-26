using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCarRace : MonoBehaviour
{
    private GameObject questCar;
    
    private void Start()
    {
        questCar = FindObjectOfType<CarRaceController>().QuestCar;
    }


    private void OnTriggerEnter2D(Collider2D objectThatTriggered)
    {
        Debug.Log($"{objectThatTriggered.name} entered the goal.");
        Debug.Log($"We are looking for {questCar.name}");
        if (objectThatTriggered.gameObject == questCar)
        {
            Debug.Log("You Win the Race");
            gameObject.transform.parent.parent.gameObject.GetComponent<CarRaceController>().raceCompltion(true,69);
        }
    }

    public void Update()
    {
        
    }
}
