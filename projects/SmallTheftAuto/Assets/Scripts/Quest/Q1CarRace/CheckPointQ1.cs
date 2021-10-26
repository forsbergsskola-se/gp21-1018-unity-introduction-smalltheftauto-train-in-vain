using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPointQ1 : MonoBehaviour
{
    private GameObject questCar;

    private void OnEnable()
    {
        questCar = FindObjectOfType<CarRaceController>().QuestCar.transform.Find("CarChassis").gameObject;
    }
    

    public void OnTriggerEnter2D(Collider2D car)
    {
        if (car.gameObject == questCar)
        {
            Debug.Log("hej");
            // this.gameObject.SetActive(false);
        }
        
    }
}
