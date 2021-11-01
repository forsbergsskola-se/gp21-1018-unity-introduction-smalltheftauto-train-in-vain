using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private TMP_Text scoreText;
    
    private int score;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            scoreText.text = "Score: " + score;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        var followCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>();
        followCamera.target = gameObject;

        scoreText = FindObjectOfType<HUD>().ScoreText;

        Score = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
