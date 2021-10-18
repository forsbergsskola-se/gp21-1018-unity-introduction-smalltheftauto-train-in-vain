using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject target;
    
    
    // Update is called once per frame
    void Update()
    {
        // Get the camera coordinates.
        var cameraCoordinates = transform.position;
        
        // Get the players coordinates
        var targetCoordinates = target.transform.position;
        //
        // transform.position = Mathf.Lerp(cameraCoordinates, targetCoordinates, 1, 1);

        Vector3 temp;
        temp.z = -10;
        temp.y = Mathf.Lerp(cameraCoordinates.y, targetCoordinates.y, 0.1f);
        temp.x = Mathf.Lerp(cameraCoordinates.x, targetCoordinates.x, 0.1f);

        Debug.Log(temp);
        Debug.Log("Target:");
        Debug.Log(targetCoordinates);
        
        transform.position = temp;
        
        // Set them as a target?

        // Slowly move the camera in that direction?

        // Accerlerate in that direction?
    }
}
