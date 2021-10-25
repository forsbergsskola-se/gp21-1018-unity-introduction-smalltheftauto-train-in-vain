using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestMenuController : MonoBehaviour
{
    public PhoneBoxInteraction PhoneBoxInteraction;

    private GameObject Player;
    
    private const KeyCode PhoneBoxInteractKey = KeyCode.F;

    private GameObject QuestUi;

    private QuestUiPopupHelper questUiPopupHelper;

    private Button ExitPhoneBoxButton;



    private void OnEnable()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.SetActive(false);
        
        questUiPopupHelper = GameObject.FindGameObjectWithTag("QuestUi").GetComponent<QuestUiPopupHelper>();
        questUiPopupHelper.ViewQuestUI(true);

        ExitPhoneBoxButton = GameObject.FindGameObjectWithTag("NoButton").GetComponent<Button>();
        ExitPhoneBoxButton.onClick.AddListener(ExitPhoneBox);
    }

    

    private void ExitPhoneBox()
    {
        questUiPopupHelper.ViewQuestUI(false);
        PhoneBoxInteraction.ExitPhoneBox();
    }
    

    
    // Update is called once per frame
    void Update()
    {
        if (!Player.activeInHierarchy && Input.GetKeyDown(PhoneBoxInteractKey))
        {
            ExitPhoneBox();
        }
    }
}
