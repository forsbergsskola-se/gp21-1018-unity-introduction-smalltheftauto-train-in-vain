using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovementID : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public Rigidbody2D rb;
    private float speed = 3f;
    // Update is called once per frame
    void Update()
    {
        


    }
}
