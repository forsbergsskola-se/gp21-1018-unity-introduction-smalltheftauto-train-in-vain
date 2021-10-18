using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private const float CameraHeightOffset = -10;
    public GameObject target;
    
    void Update()
    {
        var cameraCoordinates = transform.position;
        var targetCoordinates = target.transform.position;
        var newCameraCoordinates = Vector3.Lerp(cameraCoordinates, targetCoordinates, 0.1f);
        newCameraCoordinates.z = CameraHeightOffset;

        transform.position = newCameraCoordinates;
    }
}
