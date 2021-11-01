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
        Debug.Log("get this from line 14 weaponImage: " + weaponImage);
    }

    internal void UpdateWeaponDisplay(string weaponName)
    {
        Debug.Log("get this updating weapon display");
        weaponImage.sprite = weaponName switch
        {
            "BareHands" => BareHandsSprite,
            "Pistol" => PistolSprite,
            "MachineGun" => MachineGunSprite,
            _ => weaponImage.sprite
        };
    }
}
