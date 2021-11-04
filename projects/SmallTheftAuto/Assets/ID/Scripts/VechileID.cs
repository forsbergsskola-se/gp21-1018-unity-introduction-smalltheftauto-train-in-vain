using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VechileID : MonoBehaviour
{
    public GameObject player;

    public CarMovementID carMovementID;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.FindGameObjectWithTag("PlayerID");
        carMovementID = GetComponent<CarMovementID>();
    }

    // Update is called once per frame
    void Update()
    {
        Input.GetKeyDown(KeyCode.F);
        if (player.activeInHierarchy==true)
        {
            EnterCar();
        }
        else
        {
            LeaveCar();
        }
    }

    void EnterCar()
    {
        player.SetActive(false);
        
    }

    void LeaveCar()
    {
        player.SetActive(true);
        
    }
    
}
