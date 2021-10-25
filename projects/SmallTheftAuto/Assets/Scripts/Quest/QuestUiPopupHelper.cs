using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestUiPopupHelper : MonoBehaviour
{
    private List<GameObject> QuestUi = new List<GameObject>();
    
    public void ViewQuestUI(bool value)
    {
        foreach (GameObject childUI in QuestUi)
        {
            childUI.SetActive(value);
        }
    }

    void Start()
    {
        foreach (Transform child in transform)
        {
            QuestUi.Add(child.gameObject);
        }
    }
}
