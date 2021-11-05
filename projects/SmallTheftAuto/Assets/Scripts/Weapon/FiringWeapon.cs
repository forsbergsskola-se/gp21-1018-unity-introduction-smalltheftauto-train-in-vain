using System;
using TMPro;
using UnityEngine;

public class FiringWeapon : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private int TotalRounds;
    [SerializeField] private int CooldownTimeInSeconds;

    private TMP_Text bulletCountText;
    private GameObject reloadCoverUp;
    internal int totalRounds { get; private set; }
    internal bool isInCooldown { get; private set; }
    private PlayerWeaponController playerWeaponController;

    private void Start()
    {
        var hud = FindObjectOfType<HUD>();
        totalRounds = TotalRounds;
        bulletCountText = hud.BulletCountText;
        reloadCoverUp = hud.ReloadCoverUp;
        isInCooldown = false;
    }

    internal void Fire()
    {
        if (totalRounds == 0 || isInCooldown) return;
        isInCooldown = true;
        Invoke(nameof(SetIsInCooldownToFalse), CooldownTimeInSeconds);
        MinusOneBullet();
        InstantiateBullet();
        UpdateRemainBulletDisplay();
    }

    private void SetIsInCooldownToFalse() => isInCooldown = false;

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
        bulletCountText.enabled = totalRounds != 0;
        reloadCoverUp.SetActive(totalRounds != 0);
    }

    internal void Reload()
    {
        totalRounds = TotalRounds;
        UpdateRemainBulletDisplay();
        reloadCoverUp.SetActive(true);
        bulletCountText.enabled = true;
    }
}
