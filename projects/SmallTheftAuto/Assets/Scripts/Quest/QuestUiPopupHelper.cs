using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestUiPopupHelper : MonoBehaviour
{
    private List<GameObject> QuestUi = new List<GameObject>();

    // private string titleText; 
    private TextMeshProUGUI title; 
    private TextMeshProUGUI description; 
        
        
        
    
    public void ViewQuestUI(bool value, string Title, string Description)
    {
        foreach (GameObject childUI in QuestUi)
        {
            childUI.SetActive(value);
        }
        
        
        title.text = Title;
        description.text = Description;
        // titleText = title;
    }

    void Start()
    {
        foreach (Transform child in transform)
        {
            QuestUi.Add(child.gameObject);
        }

        // titleText = gameObject.transform.Find("QuestTitle").GetComponent<TextMeshProUGUI>().text;
        title = gameObject.transform.Find("QuestTitle").GetComponent<TextMeshProUGUI>();
        description = gameObject.transform.Find("QuestDescription").GetComponent<TextMeshProUGUI>();
    }
}
