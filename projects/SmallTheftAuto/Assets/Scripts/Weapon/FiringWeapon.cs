using UnityEngine;

public class FiringWeapon : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private int TotalRounds;
    private int totalRounds;
    private PlayerWeaponController playerWeaponController;

    private void Start()
    {
        totalRounds = TotalRounds;
        playerWeaponController = FindObjectOfType<PlayerWeaponController>();
    }

    internal void Fire()
    {
        if (totalRounds <= 0)
        {
            Debug.LogWarning("WARNING: RELOAD!");
            return;
        }
        InstantiateBullet();
        MinusOneBullet();
    }

    private void InstantiateBullet()
    {
        var initialBulletTransform = FindObjectOfType<TAG_InitialBulletPosition>().gameObject.transform;
        var position = initialBulletTransform.position;
        var rotation = initialBulletTransform.rotation;
        var bullet = Instantiate(Bullet, position, rotation);
        SetBulletDamageToActiveWeaponPower(bullet);
    }

    private void SetBulletDamageToActiveWeaponPower(GameObject bullet)
    {
        var activeWeapon = playerWeaponController.ActiveWeapon;
        bullet.GetComponent<Projectile>().BulletDamage = (int)activeWeapon.Power;
    }

    private void MinusOneBullet() => totalRounds -= 1;

    internal void Reload() => totalRounds = TotalRounds;
}
