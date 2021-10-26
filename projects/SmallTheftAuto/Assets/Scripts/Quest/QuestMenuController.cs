using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestMenuController : MonoBehaviour
{
    private GameObject player;
    private GameObject questUi;
    private QuestUiPopupHelper questUiPopupHelper;
    private Button noButton;
    private Button yesButton;
    
    private const KeyCode phoneBoxInteractKey = KeyCode.F;
    
    public PhoneBoxInteraction PhoneBoxInteraction;
    public GameObject quest;
    
    public string QuestTitle;
    public string QuestDescription;
   
    private static bool questIsActive;

    public bool QuestIsActive
    {
        get => questIsActive;
        set { questIsActive = value; }
    }
    
    
    
    
    
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.SetActive(false);
        
        questUiPopupHelper = GameObject.FindGameObjectWithTag("QuestUi").GetComponent<QuestUiPopupHelper>();
        questUiPopupHelper.ViewQuestUI(true, QuestTitle, QuestDescription);

        noButton = GameObject.FindGameObjectWithTag("NoButton").GetComponent<Button>();
        noButton.onClick.AddListener(ExitPhoneBox);
        
        yesButton = GameObject.FindGameObjectWithTag("YesButton").GetComponent<Button>();
        yesButton.onClick.AddListener(StartQuest);

    }

    
    
    private void OnDisable()
    {
        noButton.onClick.RemoveListener(ExitPhoneBox);
        yesButton.onClick.RemoveListener(StartQuest);
    }

    
    
    private void StartQuest()
    {
        if (!questIsActive)
        {
            quest.GetComponent<CarRaceController>().ActivateCarRaceQuest();
            questIsActive = true;
            ExitPhoneBox();
        }
        else
        {
            Debug.Log("QUEST ALREADY ACTIVE!");
        }
    }

    
    
    private void ExitPhoneBox()
    {
        questUiPopupHelper.ViewQuestUI(false, "", "");
        PhoneBoxInteraction.ExitPhoneBox();
    }
    

    
    // Update is called once per frame
    void Update()
    {
        if (!player.activeInHierarchy && Input.GetKeyDown(phoneBoxInteractKey))
        {
            ExitPhoneBox();
        }
    }
}
