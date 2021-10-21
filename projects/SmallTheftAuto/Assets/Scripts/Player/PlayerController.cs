using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        var followCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>();
        followCamera.target = gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
