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
    // private TextMeshProUGUI titleText;
    private TextMeshProUGUI titleText; 
        
        
        
    
    public void ViewQuestUI(bool value, string title, string description)
    {
        foreach (GameObject childUI in QuestUi)
        {
            childUI.SetActive(value);
        }
        
        
        // gameObject.GetComponentInChildren<TextMeshProUGUI>().text = title;
        titleText.text = title;
        // titleText = title;
    }

    void Start()
    {
        foreach (Transform child in transform)
        {
            QuestUi.Add(child.gameObject);
        }

        // titleText = gameObject.transform.Find("QuestTitle").GetComponent<TextMeshProUGUI>().SetText();
        titleText = gameObject.transform.Find("QuestTitle").GetComponent<TextMeshProUGUI>();
    }
}
