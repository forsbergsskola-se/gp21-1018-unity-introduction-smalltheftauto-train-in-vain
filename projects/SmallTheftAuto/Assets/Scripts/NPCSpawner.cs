using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class NPCSpawner : MonoBehaviour
{
    private List<Vector3> spawnPositions = new List<Vector3>();
    // private IEnumerable<Vector3> temp;

    public int MaxNPCs;
    private List<GameObject> NPCs = new List<GameObject>();

    public GameObject NPCPrefab;

    public Sprite[] NPCskins;

    public int[] MaxHealthRange;
    public int[] MoveSpeedRange;
    public int[] WaitTimeMaxRange;
    public int[] WaitTimeMinRange;
    public int[] PanicModeTimeRange;

    // Start is called before the first frame update
    void Start()
    {
        var tempSpawnPositions = FindObjectsOfType<TAG_PedestrianSpawnPosition>();
        spawnPositions = tempSpawnPositions.Select(x => x.transform.position).ToList();
        
        // temp = tempSpawnPositions.Select(x => x.transform.position);
        
        
        while (NPCs.Count < MaxNPCs)
        {
            SpawnNewNPC(spawnPositions[Random.Range(0, spawnPositions.Count)]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: If any NPCs are inactive teleport them to a random spawn position and enable them again with full stats.
        
        
        
        // NPCs.RemoveAll(x => x == null);
        // if (NPCs.Count < MaxNPCs)
        // {
        //     var spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Count)];
        //     SpawnNewNPC(spawnPosition);
        // }
    }


    // TODO: Cool!
    public void ReloadNPC(GameObject npcObject, Pedestrian pedestrian)
    {
        npcObject.transform.position = spawnPositions[Random.Range(0, spawnPositions.Count)];
        npcObject.GetComponent<SpriteRenderer>().sprite = NPCskins[Random.Range(0, NPCskins.Length)];
        SetRandomStats(pedestrian);
        npcObject.SetActive(true);
    }
    
    
    

    public void SpawnNewNPC(Vector3 position, Quaternion rotation = new Quaternion())
    {
        var newNPC = Instantiate(NPCPrefab);
        newNPC.transform.position = position;
        newNPC.transform.rotation = rotation;
        newNPC.GetComponent<SpriteRenderer>().sprite = NPCskins[Random.Range(0, NPCskins.Length)];

        var newNPCVariables = newNPC.GetComponent<Pedestrian>();
        
        SetRandomStats(newNPCVariables);
        
        NPCs.Add(newNPC);
    }

    void SetRandomStats(Pedestrian newNPCVariables)
    {
        newNPCVariables.MaxHealth = Random.Range(MaxHealthRange[0], MaxHealthRange[1]);
        newNPCVariables.MoveSpeed = Random.Range(MoveSpeedRange[0], MoveSpeedRange[1]);
        newNPCVariables.WaitTimeMax = Random.Range(WaitTimeMaxRange[0], WaitTimeMaxRange[1]);
        newNPCVariables.WaitTimeMin = Random.Range(WaitTimeMinRange[0], WaitTimeMinRange[1]);
        newNPCVariables.PanicModeTime = Random.Range(PanicModeTimeRange[0], PanicModeTimeRange[1]);
    }
}
