using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCarRace : MonoBehaviour
{
    public bool CarHasPassed = false;
    
    private GameObject questCar;
    
    private void OnEnable()
    {
        questCar = FindObjectOfType<CarRaceController>().QuestCar.transform.Find("CarChassis").gameObject;
    }


    private void OnTriggerEnter2D(Collider2D objectThatTriggered)
    {
        Debug.Log($"{objectThatTriggered.gameObject.name} triggered the goal. ");
        Debug.Log($"We are looking for {questCar.name}");
        
        if (objectThatTriggered.gameObject == questCar)
        {
            // Tell the CarRaceController that the race has been completed.
            CarHasPassed = true;
            FindObjectOfType<CarRaceController>().RaceCompleted(true,69);
        }
    }
}
