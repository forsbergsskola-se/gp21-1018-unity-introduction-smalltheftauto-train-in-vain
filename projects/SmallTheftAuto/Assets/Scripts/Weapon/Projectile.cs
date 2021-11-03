using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float BulletSpeed;
    internal int BulletDamage;
    private GameObject player;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        rb.AddForce(player.transform.up * BulletSpeed, ForceMode2D.Impulse);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable iDamageable))
        {
            iDamageable.TakeDamage(BulletDamage, gameObject);
            Destroy(gameObject);
        }
    }
}
