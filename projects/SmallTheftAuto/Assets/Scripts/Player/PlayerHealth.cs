using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private ResetScene ResetScene;
    private HealthBar HealthBar;
    private GameObject Wasted;
    
    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GameObject.FindWithTag("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;
        ResetScene = FindObjectOfType<ResetScene>();
        HealthBar.sethealth(maxHealth);
        Wasted = GameObject.FindWithTag("Wasted");
        Wasted.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }*/
    }

   public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.sethealth(currentHealth);
        if (currentHealth<=0)
        {
            Wasted.SetActive(true);
            // Destroy(this.gameObject);
            ResetScene.Reset();
        }
    }
}
