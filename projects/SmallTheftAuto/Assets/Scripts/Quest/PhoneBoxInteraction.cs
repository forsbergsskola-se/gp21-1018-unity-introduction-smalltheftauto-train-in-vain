using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneBoxInteraction : MonoBehaviour
{
    private GameObject Player;
    private FollowCamera FollowCamera;
    public GameObject ExitPostion;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        FollowCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>();
    }

    public void EnterPhoneBox()
    {
        if (Player == null) Player = GameObject.FindGameObjectWithTag("Player");
        
        Player.SetActive(false);

        FollowCamera.target = gameObject;
    }

    public void ExitPhoneBox()
    {
        Player.transform.position = ExitPostion.transform.position;
        
        Player.SetActive(true);

        FollowCamera.target = Player;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
