using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUiPopupHelper : MonoBehaviour
{
    private List<GameObject> QuestUi = new List<GameObject>();


    public void ViewQuestUI(bool value)
    {
        foreach (GameObject childUI in QuestUi)
        {
            childUI.active = value;
        }
        
    }
    
    void Start()
    {
        foreach (Transform child in transform)
        {
            QuestUi.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
