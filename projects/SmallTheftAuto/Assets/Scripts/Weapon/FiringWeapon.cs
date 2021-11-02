using System;
using UnityEngine;

public class FiringWeapon : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private int TotalRounds;
    private int totalRounds;

    private void Awake()
    {
        totalRounds = TotalRounds;
    }

    internal void Fire()
    {
        if (totalRounds <= 0)
        {
            Debug.LogWarning("WARNING: RELOAD!");
            return;
        }
        var bullet = Instantiate(Bullet);
        var activeWeapon = FindObjectOfType<PlayerWeaponController>().ActiveWeapon;
        bullet.GetComponent<Projectile>().BulletDamage = (int)activeWeapon.Power;
        MinusOneBullet();
    }

    private void MinusOneBullet() => totalRounds -= 1;

    internal void Reload() => totalRounds = TotalRounds;
}
