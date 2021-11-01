using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI textSlider;
    public float gameTime;
    private bool stopTime;
    int minutes;
    int seconds;
    void Start()
    {
        stopTime = false;
        slider.maxValue = gameTime;
        slider.value = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        float time = gameTime - Time.time;
        int minutes = Mathf.FloorToInt(time/60);
        int seconds = Mathf.FloorToInt(time- minutes * 60f);
        string textTime = string.Format("{00:00}: {1:00}", minutes, seconds);
        if (time<=0)
        {
            stopTime = true;
            
        }

        if (stopTime== false)
        {
            textSlider.text = textTime;
            slider.value = time;
        }
    }
    
}
