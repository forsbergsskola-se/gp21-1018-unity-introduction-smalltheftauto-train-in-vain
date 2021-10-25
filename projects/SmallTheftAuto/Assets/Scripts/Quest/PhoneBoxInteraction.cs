using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneBoxInteraction : MonoBehaviour
{
    private GameObject Player;
    private FollowCamera FollowCamera;
    public GameObject ExitPostion;
    public QuestMenuController QuestMenuController;

    private bool isEnterd;

    public bool IsEnterd
    {
        get;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hej där jag är trasig.");
        
        Player = GameObject.FindGameObjectWithTag("Player");
        
        FollowCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>();
    }

    
    
    public void EnterPhoneBox()
    {
        if (Player == null) Player = GameObject.FindGameObjectWithTag("Player");

        FollowCamera.target = gameObject;
        
        // Todo: Add ui scripts to control which quests are started
        
        QuestMenuController.enabled = true;
        
    }

    
    
    public void ExitPhoneBox()
    {
        //Debug.Log("Hej där något är skummt!");
        
        Debug.Log($"Hej jag heter {this.name}");
        
        Player.SetActive(true);
        
        Player.transform.position = ExitPostion.transform.position;
        

        FollowCamera.target = Player;
        
        
        QuestMenuController.enabled = false;
    }
}
