using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoneySpawner : MonoBehaviour
{
    public GameObject GetMoney50;
    public GameObject GetMoney100;
    public GameObject GetMoney200;
    
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoneyGet50(Vector3 spawnPostion)
    {
       
    }
    void MoneyGet100(Vector3 spawnPostion)
    {
       
    }
    public void MoneyGet200(Vector3 spawnPostion)
    {
        
        Instantiate(GetMoney200).transform.position = spawnPostion;

    }
    
}
