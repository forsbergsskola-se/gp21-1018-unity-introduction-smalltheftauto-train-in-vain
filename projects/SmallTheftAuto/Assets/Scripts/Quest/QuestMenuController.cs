using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMenuController : MonoBehaviour
{
    public PhoneBoxInteraction PhoneBoxInteraction;

    private GameObject Player;
    
    private const KeyCode PhoneBoxInteractKey = KeyCode.F;

    private GameObject QuestUi;

    private QuestUiPopupHelper questUiPopupHelper;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.SetActive(false);
        
        questUiPopupHelper = GameObject.FindGameObjectWithTag("QuestUi").GetComponent<QuestUiPopupHelper>();
        questUiPopupHelper.ViewQuestUI(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (!Player.activeInHierarchy && Input.GetKeyDown(PhoneBoxInteractKey))
        {
            questUiPopupHelper.ViewQuestUI(false);
            PhoneBoxInteraction.ExitPhoneBox();
        }
    }
}
