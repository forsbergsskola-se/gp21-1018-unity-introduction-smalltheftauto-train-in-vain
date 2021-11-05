using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class SteroidsPowerUp : MonoBehaviour
{
    private PlayerController playerController;
    public float multiplier = 1.4f;
    

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        
        if (other.CompareTag("Player"))
        {
            bulkUp(other);
            Destroy(gameObject);
        }
    }

    void bulkUp(Collider2D player)
    {
        player.transform.localScale *= multiplier;
    }
}
