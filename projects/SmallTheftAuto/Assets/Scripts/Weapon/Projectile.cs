using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float BulletSpeed;
    internal int BulletDamage;
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
        if (other.gameObject.TryGetComponent(out IDamageable iDamageable))
        {
            iDamageable.TakeDamage(BulletDamage, gameObject);
        }
        Destroy(gameObject);
    }
}
