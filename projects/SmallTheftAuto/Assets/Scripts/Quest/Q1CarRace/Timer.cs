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
    public float startTemp;
    private bool stopTime;
    int minutes;
    int seconds;
    void Start()
    {
        stopTime = false;
        slider.maxValue = gameTime;
        slider.value = gameTime;
    }

    private void OnDisable()
    {
        gameTime = startTemp;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(gameTime/60);
        int seconds = Mathf.FloorToInt(gameTime - minutes * 60f);
        string textTime = string.Format("{00:00}: {1:00}", minutes, seconds);
        if (gameTime<=0)
        {
            stopTime = true;
            
        }

        if (stopTime== false)
        {
            textSlider.text = textTime;
            slider.value = gameTime;
        }
        
    }
}
