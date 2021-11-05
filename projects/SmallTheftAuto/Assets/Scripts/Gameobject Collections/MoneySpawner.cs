using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoneySpawner : MonoBehaviour
{
    public GameObject GetMoney10;
    public GameObject GetMoney50;
    public GameObject GetMoney100;
    
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMoney10(Vector3 spawnPostion)
    {
        Instantiate(GetMoney10).transform.position = spawnPostion;

    }
    public void SpawnMoney50(Vector3 spawnPostion)
    {
        Instantiate(GetMoney50).transform.position = spawnPostion;
        // Instantiate(GetMoney50).transform.position = spawnPostion;
    }
    public void SpawnMoney100(Vector3 spawnPostion)
    {
        Instantiate(GetMoney100).transform.position = spawnPostion;
        Instantiate(GetMoney100).transform.position = spawnPostion;
    }
}
