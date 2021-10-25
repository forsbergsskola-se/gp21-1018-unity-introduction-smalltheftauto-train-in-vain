using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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
    
    private Button yesButton;
    
    public GameObject quest;

    public string QuestTitle;

    public string QuestDescription;





    private void OnEnable()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.SetActive(false);
        
        questUiPopupHelper = GameObject.FindGameObjectWithTag("QuestUi").GetComponent<QuestUiPopupHelper>();
        questUiPopupHelper.ViewQuestUI(true, QuestTitle, QuestDescription);

        ExitPhoneBoxButton = GameObject.FindGameObjectWithTag("NoButton").GetComponent<Button>();
        ExitPhoneBoxButton.onClick.AddListener(ExitPhoneBox);
        
        yesButton = GameObject.FindGameObjectWithTag("YesButton").GetComponent<Button>();
        yesButton.onClick.AddListener(StartQuest);

    }

    
    
    private void OnDisable()
    {
        ExitPhoneBoxButton.onClick.RemoveListener(ExitPhoneBox);
        yesButton.onClick.RemoveListener(StartQuest);
    }

    
    
    private void StartQuest()
    {
        quest.GetComponent<CarRaceController>().temp();
        ExitPhoneBox();
    }

    
    
    private void ExitPhoneBox()
    {
        questUiPopupHelper.ViewQuestUI(false, "", "");
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
