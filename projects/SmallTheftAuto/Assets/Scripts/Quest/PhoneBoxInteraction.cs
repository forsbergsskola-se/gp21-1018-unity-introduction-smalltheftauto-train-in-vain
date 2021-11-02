using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneBoxInteraction : MonoBehaviour, IEnterable, IInteractable
{
    private QuestMenuController questMenuController;
    private FollowCamera followCamera;
    private Transform ExitPostion;
    private GameObject currentUser;
    private bool ExitAllowed;
    
    void Start()
    {
        ExitPostion = transform.Find("ExitPosition");
        questMenuController = FindObjectOfType<QuestMenuController>();
        followCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>();
    }
    
    public void Interact(GameObject User)
    { 
        Enter(User);
    }

    public void Enter(GameObject User)
    {
        currentUser = User;
        currentUser.SetActive(false);
        followCamera.target = gameObject;
        
        // Allow the phone box to be exited after half a second.
        Invoke("ExitCooldown", 0.5f);

        questMenuController.enabled = true;
    }
    
    void ExitCooldown()
    {
        ExitAllowed = true;
    }

    public void Exit()
    {
        if (ExitAllowed)
        {
            currentUser.transform.position = ExitPostion.position;
            currentUser.transform.rotation = ExitPostion.rotation;

            currentUser.SetActive(true);
            followCamera.target = currentUser;
            
            questMenuController.enabled = false;
        }
    }
    
    // private GameObject Player;
    //
    // private bool isEnterd;
    //
    // public bool IsEnterd
    // {
    //     get;
    // }
    //
    // // Start is called before the first frame update
    //
    //
    //
    //
    // public void EnterPhoneBox()
    // {
    //     if (Player == null) Player = GameObject.FindGameObjectWithTag("Player");
    //
    //     followCamera.target = gameObject;
    //     
    //     // Todo: Add ui scripts to control which quests are started
    //     
    //     QuestMenuController.enabled = true;
    //     
    // }
    //
    //
    //
    // public void ExitPhoneBox()
    // {
    //     //Debug.Log("Hej där något är skummt!");
    //     
    //     Debug.Log($"Hej jag heter {this.name}");
    //     
    //     Player.SetActive(true);
    //     
    //     Player.transform.position = ExitPostion.transform.position;
    //     Player.transform.rotation = ExitPostion.transform.rotation;
    //     
    //
    //     FollowCamera.target = Player;
    //     
    //     
    //     QuestMenuController.enabled = false;
    // }
}
