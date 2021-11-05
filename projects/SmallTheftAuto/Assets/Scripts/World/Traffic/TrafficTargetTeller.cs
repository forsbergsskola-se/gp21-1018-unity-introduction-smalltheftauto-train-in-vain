using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrafficTargetTeller : MonoBehaviour
{
    public List<Transform> PossibleTargetTrafficPoints = new List<Transform>();
    private List<Vector3> TargetPositions = new List<Vector3>();

    private void Start()
    {
        TargetPositions = PossibleTargetTrafficPoints.Select(x => x.transform.position).ToList();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out AiDriving aiDriving))
        {
            Debug.Log("Sent positions to passing car!");
            aiDriving.TargetPositions = new List<Vector3>(TargetPositions);
        }
    }
}
