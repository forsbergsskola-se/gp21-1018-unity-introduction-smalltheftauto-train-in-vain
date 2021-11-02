using UnityEngine;

public class PlayerSpriteChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PlayerWeaponController playerWeaponController;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite armedSprite;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerWeaponController = GetComponent<PlayerWeaponController>();
    }

    // private void LateUpdate()
    // {
    //     var activeWeaponName = playerWeaponController.ActiveWeapon.WeaponName;
    //     spriteRenderer.sprite = activeWeaponName switch
    //     {
    //         WeaponName.BareHands => defaultSprite,
    //         WeaponName.Pistol => armedSprite,
    //         WeaponName.MachineGun => armedSprite,
    //         _ => spriteRenderer.sprite
    //     };
    // }
}
