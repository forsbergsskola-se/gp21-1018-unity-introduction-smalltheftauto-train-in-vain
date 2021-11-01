using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// The script controls player's weapon logic
/// "WeaponController" is a vague name, would probably rename it to something else
/// more descriptive later. 
/// </summary>
internal class PlayerWeaponController : MonoBehaviour, IEquipTarget, IAttacker
{
    private const int LeftClick = 0;
    private const KeyCode WeaponInteract = KeyCode.F;
    private const float RangeToPickUp = 5f;
    private Weapon bareHands;
    private List<Weapon> nonMeleeWeaponsInScene;
    private Weapon activeWeapon;
    
    public IEquippable Equippable { get; set; }
    public ITarget Target { get; set; }

    private void Awake()
    {
        // Bare hands as default weapon
        bareHands = gameObject.AddComponent<WeaponBareHands>();
        bareHands.EquipTo(this);
        nonMeleeWeaponsInScene = GameObject.FindObjectsOfType<Weapon>().Where(w => !(w as WeaponBareHands)).ToList();
    }

    private void Update()
    {
        if (weaponIsWithinRange() && Input.GetKeyDown(WeaponInteract))
        {
            activeWeapon.EquipTo(this);
            activeWeapon.gameObject.SetActive(false);
        }
    }

    private bool weaponIsWithinRange()
    {
        var result = false;
        foreach (var weapon in nonMeleeWeaponsInScene)
        {
            result = Vector3.Distance(gameObject.transform.position, weapon.transform.position) <= RangeToPickUp;
            if (!result) continue;
            activeWeapon = weapon;
            Debug.Log("Current active weapon: " + activeWeapon);
            break;
        }
        return result;
    }

    public void Attack(ITarget target, int damage)
    {
        Target = target;
        Target.TakeDamage(damage);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        // NOTE checking type instead of CompareTag
        // NOTE should be passing distance check instead of collision
        var gameObj = other.gameObject;
        Debug.Log("HEY AM FROM PlayerWeaponController");
        if (gameObj.CompareTag("Car") && Input.GetMouseButtonDown(LeftClick)) 
        {
            Debug.Log(Equippable);
            Attack(gameObj.GetComponent<CarTakeDamage>(), (int)Equippable.Power);
        }
    }
}
