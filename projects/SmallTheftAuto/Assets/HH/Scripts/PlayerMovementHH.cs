using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementHH : MonoBehaviour
{
    // Start is called before the first frame update
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
        rb.velocity = new Vector2(horizontal, vertical);
    }

    // Update is called once per frame
    /*void Update()
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


        
    }*/
}
