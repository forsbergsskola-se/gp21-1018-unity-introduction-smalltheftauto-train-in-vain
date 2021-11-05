using TMPro;
using UnityEngine;

public class FiringWeapon : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private int TotalRounds;
    [SerializeField] private float CooldownTimeInSeconds;
    public AudioSource GunShot;
    public AudioSource GunReload;

    internal int totalRounds { get; private set; }
    internal bool isInCooldown { get; private set; }
    private TMP_Text bulletCountText;
    private GameObject reloadCoverUp;
    private PlayerWeaponController playerWeaponController;
    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        var hud = FindObjectOfType<HUD>();
        totalRounds = TotalRounds;
        bulletCountText = hud.BulletCountText;
        reloadCoverUp = hud.ReloadCoverUp;
        isInCooldown = false;
    }

    internal void Fire()
    {
        if (totalRounds == 0 || isInCooldown) return;
        playerMovement.isAttacking = true;
        Invoke(nameof(SetShootAnimationToFalse), 0.2f);
        isInCooldown = true;
        Invoke(nameof(SetIsInCooldownToFalse), CooldownTimeInSeconds);
        MinusOneBullet();
        InstantiateBullet();
        UpdateRemainBulletDisplay();
        GunShot.Play();
    }

    private void SetIsInCooldownToFalse() => isInCooldown = false;

    private void SetShootAnimationToFalse() => playerMovement.isAttacking = false;

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
        GunReload.Play();
        totalRounds = TotalRounds;
        UpdateRemainBulletDisplay();
        reloadCoverUp.SetActive(true);
        bulletCountText.enabled = true;
    }
}
