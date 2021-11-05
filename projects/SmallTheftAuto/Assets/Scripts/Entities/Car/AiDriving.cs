using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AiDriving : MonoBehaviour
{
    public bool NPCInCar;
    public bool ClockWise;

    private bool CounterClockWise => !ClockWise;
    private Car car;
    private Transform ExitPosition;
    private List<Vector3> targetPositions = new List<Vector3>();
    private float maxSpeed;

    private int currentTargetIndex;
    private int CurrentTargetIndex
    {
        get => currentTargetIndex;
        set
        {
            currentTargetIndex = value; 
            if (currentTargetIndex == targetPositions.Count) { currentTargetIndex = 0; } 
        }
    }

    void Start()
    {
        car = GetComponent<Car>();
        ExitPosition = ExitPosition = transform.Find("CarExitPosition");
        maxSpeed = car.MaxSpeed;

        if (ClockWise)
        {
            List<TAG_ClockwiseTrafficPoint> clockWiseTrafficPoints =
                FindObjectsOfType<TAG_ClockwiseTrafficPoint>().ToList();
            Debug.Log(clockWiseTrafficPoints.Count);
            foreach (var point in clockWiseTrafficPoints)
            {
                Debug.Log(point.GetComponent<Transform>().position);
                targetPositions.Add(point.gameObject.transform.position);
            }
            // targetPositions = clockWiseTrafficPoints.FindAll(x => x.transform).ToList();
        }

        if (CounterClockWise)
        {
            List<TAG_CounterClockwiseTrafficPoint> counterClockWiseTrafficPoints =
                FindObjectsOfType<TAG_CounterClockwiseTrafficPoint>().ToList();
            foreach (var point in counterClockWiseTrafficPoints)
            {
                // targetPositions.Add(point.GetComponent<Transform>());
            }
        }
    }

    private void Update()
    {
        if (NPCInCar)
        {
            // If the car is not being driven by the player. Would be nice with a better variable name here.
            if (!car.CarRunning)
            {
                // TODO: Drive
                Drive();
            }
            else
                NPCInCar = false;
        }
    }

    void Drive()
    {
        // Check if the coordinates are the same as the current target point with method.
        CheckTarget();
        
        // Drive towards the current target point
        // transform.LookAt(targetPositions[currentTargetIndex], Vector3.forward);
        transform.up = targetPositions[currentTargetIndex] - transform.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPositions[currentTargetIndex],
            maxSpeed * Time.deltaTime);
    }

    void CheckTarget()
    {
        if (transform.position == targetPositions[currentTargetIndex])
        {
            CurrentTargetIndex++;
        }
    }
}
