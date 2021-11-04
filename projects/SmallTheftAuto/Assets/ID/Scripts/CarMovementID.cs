using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovementID : MonoBehaviour
{
    public float rotSpeed = 120f;
    public float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * rotSpeed* Time.deltaTime;
        var vertical = Input.GetAxis("Vertical") * speed*Time.deltaTime;
        transform.Translate(0,vertical,0 );
        transform.Rotate(0, 0, -horizontal);
    }
}
