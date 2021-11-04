using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : Entity, IDamageable
{
    private TMP_Text scoreText;
    private TMP_Text moneyText;

    private HealthBar healthBar;
    private GameObject Wasted;
    private GameObject Hurt;

    public static int MoneyOnDeath;
    public static int ScoreOnDeath;
    private int score;
    private int money;

    public int Money
    {
        get => money;
    }

    public int Score
    {
        get => score;
        set
        {
            score = value;
            scoreText = FindObjectOfType<HUD>().ScoreText;
            scoreText.text = "" + score;
        }
    }

    public void addMoney(int moneyToAdd)
    {
        money += moneyToAdd;
        Debug.Log("Woo-hoo, I'm rich!");
        moneyText = FindObjectOfType<HUD>().MoneyText;
        moneyText.text = ": $ " + money;
    }

    // public void subtractMoney(int moneyToSubtract)
    // {
    //     if (money - moneyToSubtract >= 0)
    //     {
    //         money -= moneyToSubtract;
    //         Debug.Log("Nooo! My precious money!");
    //         moneyText = FindObjectOfType<HUD>().MoneyText;
    //         moneyText.text = ": $ " + money;
    //     }
    // }

    void Start()
    {
        var followCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowCamera>();
        Debug.Log(followCamera.name);
        followCamera.target = gameObject;

        healthBar = FindObjectOfType<HealthBar>();
        
        scoreText = FindObjectOfType<HUD>().ScoreText;
        Score = 0;
        
        Wasted = GameObject.FindWithTag("Wasted");
        Wasted.SetActive(false);
        Hurt = GameObject.FindWithTag("Hurt");
        Hurt.SetActive(false);
        
        healthBar.MaxHealth(MaxHealth);
    }
  
    void Update()
    {
        moneyText = FindObjectOfType<HUD>().MoneyText;
        moneyText.text = ": $ " + money;
    }

    
    
    public override void TakeDamage(int value, GameObject attacker = null)
    {
        base.TakeDamage(value, attacker);
        healthBar.SetHealth(Health);
        
        if (Health < MaxHealth * 0.4 && Health > 0)
        {
            Hurt.SetActive(true);
        }
        else
        {
            Hurt.SetActive(false);
        }
    }

    public override void OnDeath()
    {
        Wasted.SetActive(true);
        GetComponent<PlayerMovement>().enabled = false;

        
        StartCoroutine(DeathScreenDelay());
        Debug.Log("Hi im dead");
    }

    IEnumerator DeathScreenDelay()
    {
        yield return new WaitForSeconds(3);
        ScoreOnDeath = score;
        MoneyOnDeath = money;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
