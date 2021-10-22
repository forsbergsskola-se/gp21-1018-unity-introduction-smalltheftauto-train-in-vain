using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMenuController : MonoBehaviour
{
    public PhoneBoxInteraction PhoneBoxInteraction;

    private GameObject Player;
    
    private const KeyCode PhoneBoxInteractKey = KeyCode.F;
    
    
    
    private void OnEnable()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    
    
    // Update is called once per frame
    void Update()
    {
        if (!Player.activeInHierarchy && Input.GetKeyDown(PhoneBoxInteractKey))
        {
            PhoneBoxInteraction.ExitPhoneBox();
        }
    }
}
