using TMPro;
using UnityEngine;

public class FiringWeapon : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private int TotalRounds;
    
    private TMP_Text bulletCountText;
    private GameObject reloadCoverUp;
    private int totalRounds;
    private PlayerWeaponController playerWeaponController;

    private void Start()
    {
        totalRounds = TotalRounds;
        bulletCountText = FindObjectOfType<HUD>().BulletCountText;
        reloadCoverUp = FindObjectOfType<HUD>().ReloadCoverUp;
    }

    internal void Fire()
    {
        if (totalRounds == 0)
        {
            return;
        }
        MinusOneBullet();
        InstantiateBullet();
        UpdateRemainBulletDisplay();
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
        playerWeaponController = FindObjectOfType<PlayerWeaponController>();
        var activeWeapon = playerWeaponController.ActiveWeapon;
        bullet.GetComponent<Projectile>().BulletDamage = (int)activeWeapon.Power;
    }

    private void MinusOneBullet()
    {
        totalRounds -= 1;
        UpdateRemainBulletDisplay();
    }

    internal void UpdateRemainBulletDisplay()
    {
        bulletCountText.text = totalRounds.ToString();
        if (totalRounds == 0)
        {
            bulletCountText.enabled = false;
            reloadCoverUp.SetActive(false);
        }
    }

    internal void Reload()
    {
        totalRounds = TotalRounds;
        UpdateRemainBulletDisplay();
        reloadCoverUp.SetActive(true);
        bulletCountText.enabled = true;
    }
}
