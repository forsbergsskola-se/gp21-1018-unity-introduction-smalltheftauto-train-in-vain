using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WastedDeathComeUp : MonoBehaviour
{
    public PlayerHealth Health;
    private GameObject Player;

    
    // Start is called before the first frame update
    void Start()
    {
        Health = GameObject.FindWithTag("Wasted").GetComponent<PlayerHealth>();
        Player = (GameObject.FindGameObjectWithTag ("Player"));

    }

    // Update is called once per frame
    void Update()
    {
        if (Health.currentHealth>=0 || Player.IsDestroyed())
        {
            Health.enabled = true;
        }
    }
}
