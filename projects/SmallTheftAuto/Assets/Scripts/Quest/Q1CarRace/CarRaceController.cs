using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRaceController : MonoBehaviour
{
    private GameObject phoneBox;
    public SpawnCar SpawnCar;
    private GameObject raceCar;
    public GameObject CarSpawnPosition;
    public FinishCarRace finishCarRace;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void temp()
    {
        SpawnCar.Spawn(CarSpawnPosition.transform.position, new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void raceCompltion(bool playerWin, int totalTime)
    {
        if (playerWin)
        {
            GameObject.FindGameObjectWithTag("PhoneBox").GetComponent<QuestMenuController>().QuestIsActive = false;
        }
    }
}
