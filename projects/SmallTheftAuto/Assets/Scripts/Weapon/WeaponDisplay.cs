using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    [SerializeField] private Sprite BareHandsSprite;
    [SerializeField] private Sprite PistolSprite;
    [SerializeField] private Sprite MachineGunSprite;
    private Image weaponImage;
    
    void Awake()
    {
        weaponImage = FindObjectOfType<HUD>().WeaponImage;
    }

    internal void UpdateWeaponDisplay(string weaponName)
    {
        weaponImage.sprite = weaponName switch
        {
            "BareHands" => BareHandsSprite,
            "Pistol" => PistolSprite,
            "MachineGun" => MachineGunSprite,
            _ => weaponImage.sprite
        };
    }
}
