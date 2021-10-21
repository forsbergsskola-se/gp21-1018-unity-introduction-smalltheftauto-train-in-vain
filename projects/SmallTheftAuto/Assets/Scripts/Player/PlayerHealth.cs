using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public int maxHealth = 100;

    public int currentHealth;

    private HealthBar HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar = GameObject.FindWithTag("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;
        HealthBar.sethealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.sethealth(currentHealth);
        if (currentHealth<=0)
        {
            Destroy(this.gameObject);
            Debug.Log("Player is dead.");
        }
    }

}
