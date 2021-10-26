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
        QuestCar = SpawnCar.SpawnAndReturn(CarSpawnPosition.transform.position, CarSpawnPosition.transform.rotation);
        DisplayQuest(true);
    }
    
    

    /// <summary>
    /// RaceCompleted
    /// </summary>
    /// <param name="playerWin">True or false for if the player wom.</param>
    /// <param name="totalTime">Total time of race.</param>
    public void RaceCompleted(bool playerWin, int totalTime)
    {
        if (playerWin)
        {
            Debug.Log($"You won the race!");
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
