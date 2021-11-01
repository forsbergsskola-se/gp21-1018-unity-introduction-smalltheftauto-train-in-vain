using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResetButtonID : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject parent = new GameObject("GoldView");
        GameObject child = new GameObject("GoldViewChild");
        child.transform.SetParent(parent.transform);
        Text text = child.AddComponent<Text>();
        text.text = "This is a gold view.";
    }

    private void OnDestroy()
    {
        Debug.Log("Game have Restart");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
