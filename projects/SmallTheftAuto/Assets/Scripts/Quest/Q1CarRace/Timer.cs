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
    public float gameTime=10;
    public float startTime=10;
    private bool stopTime;
    public GameObject carRaceController;
    int minutes;
    int seconds;

    private void OnDisable()
    {
        gameTime=startTime;
        slider.maxValue = gameTime;
        slider.value = gameTime;
        stopTime = true;
    }

    private void OnEnable()
    {
        slider.maxValue = gameTime;
        slider.value = gameTime;
        stopTime = false;
        
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
            carRaceController.GetComponent<CarRaceController>().DisableLoseTextInvoke();

        }

        else if (stopTime== false)
        {
            textSlider.text = textTime;
            slider.value = gameTime;
        }
    }
}
