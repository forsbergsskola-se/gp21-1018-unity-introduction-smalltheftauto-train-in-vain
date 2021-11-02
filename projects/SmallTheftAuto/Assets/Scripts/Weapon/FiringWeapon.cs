using UnityEngine;

public class FiringWeapon : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;

    internal void Fire()
    {
        var bullet = Instantiate(Bullet);
        var activeWeapon = FindObjectOfType<PlayerWeaponController>().ActiveWeapon;
        bullet.GetComponent<Projectile>().BulletDamage = (int)activeWeapon.Power;
    }
}
