using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class AiDriving : MonoBehaviour
{
    public bool NPCInCar;
   
    private Car car;
    private Transform ExitPosition;
    private float maxSpeed;

    // Control variables:
    public List<Vector3> TargetPositions;
    private Vector3 target;

    private void Update()
    {
        if (NPCInCar)
        {
            if (!car.CarRunning)
            {
                Drive();
            }
            else
            {
                NPCInCar = false;
                // TODO: Spawn NPC at coordinates of exit position;
            }
        }
    }


    public Vector3 temp;

    void Drive()
    {
        if (TargetPositions.Count != 0)
        {
            target = TargetPositions[Random.Range(0, TargetPositions.Count)];
            TargetPositions.Clear();
            temp = target;
        }

        if (target == null)
        {
            target = FindObjectOfType<TAG_TrafficPoint>().gameObject.transform.position;
        }
        
        transform.up = target - transform.position;
        transform.position = Vector2.MoveTowards(transform.position, target,
            maxSpeed * Time.deltaTime);
    }
    

    void Start()
    {
        car = GetComponent<Car>();
        ExitPosition = ExitPosition = transform.Find("CarExitPosition");
        maxSpeed = car.BaseSpeed;

        float shortestDistance = 9999;
        var temp = FindObjectsOfType<TAG_TrafficPoint>().ToList();
        foreach (TAG_TrafficPoint t in temp)
        {
            var temp3 = t.gameObject.transform.position;
            if (Vector3.Distance(transform.position, temp3) < shortestDistance)
            {
                target = temp3;
                shortestDistance = Vector3.Distance(transform.position, temp3);
            }
        }

    }
}
