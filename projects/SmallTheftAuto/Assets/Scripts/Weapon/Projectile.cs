using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float BulletSpeed;
    internal int BulletDamage;
    private SpriteRenderer bulletRenderer;
    private Rigidbody2D rb;
    private GameObject player;

    private void Awake()
    {
        bulletRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // private void Start()
    // {
    //     var player = GameObject.FindGameObjectWithTag("Player");
    //     transform.position = player.transform.position + new Vector3(0, bulletRenderer.bounds.size.y, 0);
    // }

    private void FixedUpdate()
    {
        // transform.position += new Vector3(0, 1, 0) * BulletSpeed;
        rb.AddForce(player.transform.up * BulletSpeed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // if (other.gameObject.TryGetComponent(out IDamageable iDamageable))
        if (!other.CompareTag("Player") && other.gameObject.TryGetComponent(out IDamageable iDamageable))
        {
            iDamageable.TakeDamage(BulletDamage, gameObject);
            Destroy(gameObject);
        }
    }
}
