using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject firePrefab;

    public void SpawnFire(Vector3 position)
    {
        Instantiate(firePrefab).transform.position = position;
    }
}
