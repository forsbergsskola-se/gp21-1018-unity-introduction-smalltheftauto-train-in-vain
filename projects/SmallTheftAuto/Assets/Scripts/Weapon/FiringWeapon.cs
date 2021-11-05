using System;
using TMPro;
using UnityEngine;

public class FiringWeapon : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private int TotalRounds;
    
    private TMP_Text bulletCountText;
    private GameObject reloadCoverUp;
    private GameObject reloadPrompt;
    private Animator animator;
    internal int totalRounds { get; private set; }
    private PlayerWeaponController playerWeaponController;

    private void Start()
    {
        var hud = FindObjectOfType<HUD>();
        totalRounds = TotalRounds;
        bulletCountText = hud.BulletCountText;
        reloadCoverUp = hud.ReloadCoverUp;
        animator = GetComponent<Animator>();
        reloadPrompt = hud.ReloadPrompt;
    }

    internal void Fire()
    {
        if (totalRounds == 0)
        {
            //reloadPrompt.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.magenta, Mathf.PingPong(Time.time, 1));
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
