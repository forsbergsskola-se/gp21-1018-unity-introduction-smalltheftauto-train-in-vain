using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUiPopupHelper : MonoBehaviour
{
    public GameObject QuestUi;
    

    
    
    public void ViewQuestUI(bool value)
    {
        QuestUi.SetActive(value);
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
