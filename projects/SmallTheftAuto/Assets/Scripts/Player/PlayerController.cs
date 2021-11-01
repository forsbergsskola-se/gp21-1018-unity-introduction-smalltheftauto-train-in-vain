using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private TMP_Text scoreText;
    private TMP_Text moneyText;
    
    private int score;
    private int money;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            scoreText.text = "Score: " + score;
        }
    }

    void AddMoney(int moneyToAdd)
    {
        
    }
    
    public int Money
    {
        get => money;
        set
        {
            money = value;
            moneyText.text = ": $ " + money + ".00";
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        var followCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>();
        followCamera.target = gameObject;

        scoreText = FindObjectOfType<HUD>().ScoreText;
        moneyText = FindObjectOfType<HUD>().MoneyText;

        Score = 50;
        Money = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
