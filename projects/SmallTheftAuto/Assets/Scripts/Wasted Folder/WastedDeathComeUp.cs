using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WastedDeathComeUp : MonoBehaviour
{
    public PlayerHealth Health;
    
    // Start is called before the first frame update
    void Start()
    {
        Health = GameObject.FindWithTag("Wasted").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.currentHealth>=0)
        {
            Health.enabled = true;
        }
    }
}
