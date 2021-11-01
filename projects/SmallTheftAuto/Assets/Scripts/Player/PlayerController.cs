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

    void addMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        Debug.Log("Woo-hoo, I'm rich!");
    }

    void subtractMoney(int moneyToSubtract)
    {
        if (money - moneyToSubtract >= 0)
        {
            money -= moneyToSubtract;
            Debug.Log("Nooo! My precious money!");
        }
    }

    void Start()
    {
        var followCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>();
        followCamera.target = gameObject;

        scoreText = FindObjectOfType<HUD>().ScoreText;
        Score = 50;
    }
  
    void Update()
    {
        moneyText = FindObjectOfType<HUD>().MoneyText;
        moneyText.text = ": $ " + money;
        
        if (Input.GetMouseButtonDown(0))
        {
            addMoney(50);
        }

        else if (Input.GetMouseButtonDown(1))
        {
            subtractMoney(50);
        }
    }
}
