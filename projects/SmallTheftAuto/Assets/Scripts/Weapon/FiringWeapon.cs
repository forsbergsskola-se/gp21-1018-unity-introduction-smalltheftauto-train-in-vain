using UnityEngine;

public class FiringWeapon : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private int TotalRounds;
    private int totalRounds;
    private GameObject player;
    private PlayerWeaponController playerWeaponController;

    private void Start()
    {
        totalRounds = TotalRounds;
        player = GameObject.FindGameObjectWithTag("Player");
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
        var position = player.transform.position;
        var rotation = player.transform.rotation;
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
