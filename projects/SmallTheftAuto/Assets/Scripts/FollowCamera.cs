using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float CameraHeightOffset = -40;
    public GameObject target;
    
    void Update()
    {
        var cameraCoordinates = transform.position;
        var targetCoordinates = target.transform.position;
        var newCameraCoordinates = Vector3.Lerp(cameraCoordinates, targetCoordinates, 0.1f);
        // newCameraCoordinates.; = CameraHeightOffset;

        transform.position = new Vector3(newCameraCoordinates.x, newCameraCoordinates.y, CameraHeightOffset);
    }
}
