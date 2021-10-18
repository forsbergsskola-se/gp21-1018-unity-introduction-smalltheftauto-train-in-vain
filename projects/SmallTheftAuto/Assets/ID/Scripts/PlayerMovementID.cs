using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovementID : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal") * speed;
        var vertical = Input.GetAxis("Vertical") * speed;
        vertical *= Time.deltaTime;
        horizontal *= Time.deltaTime;
        transform.Translate(0,vertical,0 );
        transform.Rotate(horizontal,0, horizontal);
        
        
    }
}
