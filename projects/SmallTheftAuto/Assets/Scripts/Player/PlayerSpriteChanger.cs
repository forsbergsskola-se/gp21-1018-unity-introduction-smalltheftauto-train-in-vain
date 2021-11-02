using UnityEngine;

public class PlayerSpriteChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PlayerWeaponController playerWeaponController;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite armedSprite;

    private void Awake()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerWeaponController = gameObject.GetComponent<PlayerWeaponController>();
    }

    private void LateUpdate()
    {
        spriteRenderer.sprite = playerWeaponController.ActiveWeapon.WeaponName switch
        {
            "BareHands" => defaultSprite,
            "Pistol" => armedSprite,
            "MachineGune" => armedSprite,
            _ => spriteRenderer.sprite
        };
    }
}
