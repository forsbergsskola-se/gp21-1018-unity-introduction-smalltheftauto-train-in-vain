using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOA : MonoBehaviour
{
    void OnDestroy()
    {
        Debug.Log("Im destroyed");
    }

    void Awake()
    {
        Debug.Log("I am awake");
    }

    void OnEnable()
    {
        Debug.Log("I am Enabled");
    }

    void OnDisable()
    {
        Debug.Log("I am disabled");
    }

    void Start()
    {
        Debug.Log("I have started");
    }

    void Update()
    {
        // We move 5 Units scaled by the Time (per second) scaled by the User Up-Input
        transform.Translate(0f, 5f*Time.deltaTime*Input.GetAxis("Vertical"), 0f);
        // We rotate -180 Degrees scaled by the Time (per second) scaled by the User-Right-Input
        transform.Rotate(0f, 0f, -180f*Time.deltaTime*Input.GetAxis("Horizontal"));
    }
}
