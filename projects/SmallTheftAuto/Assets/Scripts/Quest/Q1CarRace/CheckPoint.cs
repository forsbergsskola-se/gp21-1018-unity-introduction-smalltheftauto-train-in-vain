using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool CarHasPassed = false;
    
    private GameObject questCar;
    

    private void OnEnable()
    {
        questCar = FindObjectOfType<CarRaceController>().QuestCar.transform.Find("CarChassis").gameObject;
    }
    

    public void OnTriggerEnter2D(Collider2D car)
    {
        if (car.gameObject == questCar)
        {
            CarHasPassed = true;
            Debug.Log($"Car passed checkpoint.");
            gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
            // this.gameObject.SetActive(false);
        }
    }
}
