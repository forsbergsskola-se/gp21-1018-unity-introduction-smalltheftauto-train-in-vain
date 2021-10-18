using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHH : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, 0.05f, 0f);
            transform.Rotate(0,0,0);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, -0.05f, 0f);
            transform.Rotate(0,0,180);

        }
        
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-0.05f, 0f, 0f);
            transform.Rotate(0,0,90);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.05f, 0f, 0f);
            transform.Rotate(0,0,270);

        }


        
    }
}
