using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCarRace : MonoBehaviour
{
    private GameObject questCarCollider;
    
    private void Start()
    {
        questCarCollider = FindObjectOfType<CarRaceController>().QuestCar.transform.Find("CarChassis").gameObject;
    }


    private void OnTriggerEnter2D(Collider2D objectThatTriggered)
    {
        if (objectThatTriggered.gameObject == questCarCollider)
        {
            // Tell the CarRaceController that the race has been completed.
            gameObject.transform.parent.parent.gameObject.GetComponent<CarRaceController>().RaceCompleted(true,69);
        }
    }

    public void Update()
    {
        
    }
}
