using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePassenger : MonoBehaviour
{
    public GameObject Player;
    private CarMovement CarMovement;
    public GameObject ExitPosition;

    void Awake()
    {
        CarMovement = gameObject.GetComponent<CarMovement>();
    }

    public void Enter()
    {
        Player.SetActive(false);
        CarMovement.enabled = true;
    }

    public void Exit()
    {
        Player.transform.position = ExitPosition.transform.position;
        
        Player.SetActive(true);
        CarMovement.enabled = false;
    }
}
