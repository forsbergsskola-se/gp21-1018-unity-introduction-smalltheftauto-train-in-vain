using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRaceController : MonoBehaviour
{
    private GameObject phoneBox;
    public GameObject carPrefab;
    private GameObject raceCar;
    public GameObject carSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void temp()
    {
        raceCar = Instantiate(carPrefab);
        raceCar.transform.position= carSpawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
