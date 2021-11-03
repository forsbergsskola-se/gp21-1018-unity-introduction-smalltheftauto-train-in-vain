using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    private ResetScene ResetScene;
    private HealthBar HealthBar;
    private GameObject Wasted;
    private GameObject Hurt;

    void Start()
    {
        HealthBar = GameObject.FindWithTag("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;
        ResetScene = FindObjectOfType<ResetScene>();
        HealthBar.sethealth(maxHealth);
        Wasted = GameObject.FindWithTag("Wasted");
        Wasted.SetActive(false);
        Hurt = GameObject.FindWithTag("Hurt");
        Hurt.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.sethealth(currentHealth);

        // trigger Hurt
        
        if ((currentHealth <= 40) && (currentHealth >0))
        {
            Hurt.SetActive(true);
        }
        
        // trigger Wasted, disable movement
        
        else if (currentHealth<=0)
        {
            Wasted.SetActive(true);
            this.GetComponent<PlayerMovement>().enabled = false;
            GameOver();
        }
    }

   // wait 5 seconds before resetting scene
   void GameOver()
   {
       StartCoroutine(SelfDestruct());
   }
   IEnumerator SelfDestruct()
   {
       yield return new WaitForSeconds(5f);
       ResetScene.ResetLevel();
   }
}
