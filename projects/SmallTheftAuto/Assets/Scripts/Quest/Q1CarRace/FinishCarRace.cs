using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishCarRace : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("You Win the Race");
        gameObject.transform.parent.gameObject.GetComponent<CarRaceController>().raceCompltion(true,69);
    }

    public void Update()
    {
        
    }
}
