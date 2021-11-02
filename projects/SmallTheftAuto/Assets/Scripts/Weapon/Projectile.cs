using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float BulletSpeed;
    private SpriteRenderer bulletRenderer;

    private void Awake()
    {
        bulletRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + new Vector3(0, bulletRenderer.bounds.size.y, 0);
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 1, 0) * BulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // should do damage here as well
        Destroy(gameObject);
    }
}
