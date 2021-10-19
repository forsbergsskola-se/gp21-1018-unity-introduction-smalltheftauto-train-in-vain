using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodBoiSpawnerHH : MonoBehaviour
{
    public GameObject DogPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(DogPrefab);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
