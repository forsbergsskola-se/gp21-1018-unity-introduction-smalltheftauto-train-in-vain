using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float BulletSpeed;
    internal int BulletDamage;
    private Rigidbody2D rb;
    private const float lifeSpan = 3f;
    private float timer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.AddForce(transform.up * BulletSpeed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > lifeSpan) Destroy(gameObject);
    }

    public DamageType DamageType;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable iDamageable))
        {
            iDamageable.TakeDamage(BulletDamage, DamageType);
            Destroy(gameObject);
        }
    }
}
