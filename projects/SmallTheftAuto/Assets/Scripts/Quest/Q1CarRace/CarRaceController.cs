using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RenderSettings = UnityEngine.Experimental.GlobalIllumination.RenderSettings;

public class CarRaceController : MonoBehaviour
{
    private List<GameObject> carRaceComponents = new List<GameObject>();
    private List<GameObject> placedPrefabs = new List<GameObject>();
    private List<GameObject> checkPointPostions = new List<GameObject>();
    private PlayerController playerController;
    public AudioSource carMusic;
    public AudioSource WorldMusic;
    
    public SpawnCar SpawnCar;
    public GameObject CarSpawnPosition;
    private const float cooldown = 4f;
    
    public GameObject GoalPrefab;
    public GameObject CheckPointPrefab;
    public GameObject Slider;
    public GameObject winText;
    public GameObject loseText;
    private MoneySpawner moneySpawner;
    public GameObject player;
    
    public GameObject QuestCar { get; private set; }

    
    
    // Start is called before the first frame update
    void Start()
    {
        
        foreach (Transform child in transform)
        {
            carRaceComponents.Add(child.gameObject);
        }

        Slider = FindObjectOfType<HUD>().QuestTimer;
        DisplayQuest(false);
        ScanCheckPointPosition();
        moneySpawner = FindObjectOfType<MoneySpawner>();
        
        //playerController = FindObjectOfType<PlayerController>();
    }
    

    public void ActivateCarRaceQuest()
    {
        QuestCar = SpawnCar.SpawnUpgradedAndReturn(CarSpawnPosition.transform.position, CarSpawnPosition.transform.rotation);
        var goalObject = Instantiate(GoalPrefab, transform);
        goalObject.transform.position = transform.Find("FinishPosition").gameObject.transform.position;
        goalObject.transform.rotation = transform.Find("FinishPosition").gameObject.transform.rotation;
        placedPrefabs.Add(goalObject);
        Slider.SetActive(true);
        DisplayQuest(true);
        PlaceCheckPoints();
        carMusic.Play();
        WorldMusic.Stop();
    }

    private void PlaceCheckPoints()
    {
        foreach (var checkPointPostion in checkPointPostions)
        {
            var checkpoint = Instantiate(CheckPointPrefab, transform);
            checkpoint.transform.position = checkPointPostion.transform.position;
            checkpoint.transform.rotation = checkPointPostion.transform.rotation;
            placedPrefabs.Add(checkpoint);
        }
        
    }

    void ScanCheckPointPosition()
    {
        var currentPostion = gameObject;
        for (int index = 1; currentPostion != null; index++)
        {
            try
            {
                currentPostion = transform.Find("CheckPointPosition" + index).gameObject;
                checkPointPostions.Add(currentPostion);
            }
            catch 
            {
                currentPostion = null;
            }
        }
    }

    /// <summary>
    /// RaceCompleted
    /// </summary>
    /// <param name="playerWin">True or false for if the player wom.</param>
    /// <param name="totalTime">Total time of race.</param>
    public void RaceCompleted(bool playerWin, int totalTime)
    {
        var AllCheckPointsCollected = true;
        
        foreach (GameObject objectData in placedPrefabs)
        {
            if (objectData.TryGetComponent<CheckPoint>(out var checkPoint))
            {
                
                Debug.Log($"Checking: {checkPoint.CarHasPassed}");
                AllCheckPointsCollected = checkPoint.CarHasPassed;
                if (!AllCheckPointsCollected)
                    break;
            }
        }
        
        if (playerWin && AllCheckPointsCollected)
        {
            Debug.Log($"You won the race!");
            Slider.SetActive(false);
            winText.SetActive(true);
            Invoke(nameof(DisableWinText),cooldown);
            QuestCar.GetComponent<Car>().Exit();
            Destroy(QuestCar);
            Debug.Log(player.gameObject.name);
            moneySpawner.MoneyGet100(player.transform.position + new Vector3(3, 0));
            moneySpawner.MoneyGet100(player.transform.position + new Vector3(-3, 0));

        }
        // else if(Slider.GetComponent<Timer>().gameTime== 0)
        // {
        //     Slider.SetActive(false);
        //     loseText.SetActive(true);
        //     Invoke(nameof(DisableLoseText),cooldown);
        // }
        else
        {
            Debug.Log("You didn't get all the checkpoints! Try again!");
            Slider.SetActive(false);
            loseText.SetActive(true);
            Invoke(nameof(DisableLoseText),cooldown);
            QuestCar.GetComponent<Car>().Exit();
            Destroy(QuestCar);
            //playerController.subtractMoney(10);
        }
        carMusic.Stop();
        WorldMusic.Play();
        GameObject.FindGameObjectWithTag("PhoneBox").GetComponent<QuestMenuController>().QuestIsActive = false;
        DisplayQuest(false);
    }


    private void DisplayQuest(bool value)
    {
        foreach (GameObject childComponent in carRaceComponents)
        {
            childComponent.SetActive(value);
        }

        if (!value)
        {
            Debug.Log("Destroyed prefabs");
            ResetQuest();
        }
    }

    private void ResetQuest()
    {
        foreach (var prefab in placedPrefabs)
        {
            Destroy(prefab);
             
        } 
        placedPrefabs = new List<GameObject>();
    }

    public void DisableWinText()
    {
        winText.SetActive(false);
    }

    public void DisableLoseText()
    {
        loseText.SetActive(false);
    }

    public void DisableLoseTextInvoke()
    {
        Slider.SetActive(false);
        loseText.SetActive(true);
        Invoke(nameof(DisableLoseText),cooldown);
        GameObject.FindGameObjectWithTag("PhoneBox").GetComponent<QuestMenuController>().QuestIsActive = false;
        DisplayQuest(false);
        QuestCar.GetComponent<Car>().Exit();
        Destroy(QuestCar);
        carMusic.Stop();
        WorldMusic.Play();
        
    }
    
}
