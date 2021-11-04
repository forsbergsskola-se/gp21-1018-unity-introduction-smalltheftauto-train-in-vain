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

    // Start is called before the first frame update
    void Start()
    {
        var tempSpawnPositions = FindObjectsOfType<TAG_PedestrianSpawnPosition>();
        spawnPositions = tempSpawnPositions.Select(x => x.transform.position).ToList();
        
        // temp = tempSpawnPositions.Select(x => x.transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        NPCs.RemoveAll(x => x == null);
        if (NPCs.Count < MaxNPCs)
        {
            var newNPC = Instantiate(NPCPrefab);
            var temp = Random.Range(0, spawnPositions.Count);
            newNPC.transform.position = spawnPositions[temp];
            Debug.Log("Spawned a new NPC at spawnID: " + temp);
            NPCs.Add(newNPC);
            Debug.Log($"NPC has nr: {NPCs.Count}");
        }
    }
}
