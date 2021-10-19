using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScriptHH : MonoBehaviour
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
        rb.velocity = new Vector2(horizontal, vertical);
    }
}
