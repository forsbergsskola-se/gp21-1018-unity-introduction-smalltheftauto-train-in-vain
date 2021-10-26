using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRaceController : MonoBehaviour
{
    private List<GameObject> carRaceComponents = new List<GameObject>();
    
    public SpawnCar SpawnCar;
    public GameObject CarSpawnPosition;
    
    public GameObject QuestCar { get; private set; }

    
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            carRaceComponents.Add(child.gameObject);
        }
        
        DisplayQuest(false);
    }

    
    
    public void ActivateCarRaceQuest()
    {
        DisplayQuest(true);
        QuestCar = SpawnCar.SpawnAndReturn(CarSpawnPosition.transform.position, new Vector3(0, 0, 0));
    }
    
    

    public void raceCompltion(bool playerWin, int totalTime)
    {
        if (playerWin)
        {
            GameObject.FindGameObjectWithTag("PhoneBox").GetComponent<QuestMenuController>().QuestIsActive = false;
            DisplayQuest(false);
        }
    }


    private void DisplayQuest(bool value)
    {
        foreach (GameObject childComponent in carRaceComponents)
        {
            childComponent.SetActive(value);
        }
    }
}
