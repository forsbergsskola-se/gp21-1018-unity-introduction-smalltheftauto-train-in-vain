using TMPro;
using UnityEditor.Animations;
using UnityEngine;

public class FiringWeapon : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private int TotalRounds;
    
    private TMP_Text bulletCountText;
    private GameObject reloadCoverUp;
    internal int totalRounds { get; private set; }
    private PlayerWeaponController playerWeaponController;

    public Animation fireAnimation;
    public RuntimeAnimatorController temp;

    private Animator playerAnimator;

    private void Start()
    {
        var hud = FindObjectOfType<HUD>();
        totalRounds = TotalRounds;
        bulletCountText = hud.BulletCountText;
        reloadCoverUp = hud.ReloadCoverUp;
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
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
        // playerAnimator.enabled = true;
        playerAnimator.runtimeAnimatorController = temp;
        Debug.Log("TITTA JAG SKJUTER");
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
