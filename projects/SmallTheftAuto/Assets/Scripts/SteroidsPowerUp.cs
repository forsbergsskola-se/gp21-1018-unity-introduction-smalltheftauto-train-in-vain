using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class SteroidsPowerUp : MonoBehaviour
{
    private PlayerController playerController;
    public float multiplier = 1.4f;
    public float duration = 20f;
    
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        
        if (other.CompareTag("Player"))
        {
            StartCoroutine(bulkUp(other));
        }
    }

    IEnumerator bulkUp(Collider2D player)
    {
        player.transform.localScale *= multiplier;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(duration);
        player.transform.localScale /= multiplier;
    }
}
