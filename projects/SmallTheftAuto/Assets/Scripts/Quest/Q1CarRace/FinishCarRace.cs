using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCarRace : MonoBehaviour
{
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
            gameObject.transform.parent.parent.gameObject.GetComponent<CarRaceController>().RaceCompleted(true,69);
        }
    }

    public void Update()
    {
        
    }
}
