using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePassenger : MonoBehaviour
{
    public GameObject Player;
    private CarMovement CarMovement;

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
        Player.SetActive(true);
        CarMovement.enabled = false;
    }
}
