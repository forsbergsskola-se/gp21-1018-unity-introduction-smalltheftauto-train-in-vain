using System;
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
    [SerializeField] private Weapon ActiveWeapon;
    private const int LeftClick = 0;
    private const KeyCode WeaponInteract = KeyCode.F;
    private const float RangeToPickUp = 5f;
    private List<Weapon> nonMeleeWeaponsInScene;

    public IEquippable Equippable { get; set; }
    public ITarget Target { get; set; }

    private void Awake()
    {
        if (ActiveWeapon == null) throw new Exception("Default weapon missing! Please assign a default weapon.");
        ActiveWeapon.EquipTo(this);
        nonMeleeWeaponsInScene = FindObjectsOfType<Weapon>().Where(w => !(FindObjectOfType<Melee>())).ToList();
        Debug.Log("Get this non Melee weapons: " + nonMeleeWeaponsInScene);
    }

    private void Update()
    {
        if (weaponIsWithinRange() && Input.GetKeyDown(WeaponInteract))
        {
            ActiveWeapon.EquipTo(this);
            ActiveWeapon.gameObject.SetActive(false);
        }
    }

    private bool weaponIsWithinRange()
    {
        var result = false;
        foreach (var weapon in nonMeleeWeaponsInScene)
        {
            result = Vector3.Distance(gameObject.transform.position, weapon.transform.position) <= RangeToPickUp;
            if (!result) continue;
            ActiveWeapon = weapon;
            Debug.Log("Current active weapon: " + ActiveWeapon);
            break;
        }
        return result;
    }

    public void Attack(ITarget target)
    {
        Target = target;
        Target.TakeDamage((int)ActiveWeapon.Power);
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
            Attack(gameObj.GetComponent<CarTakeDamage>());
        }
    }
}
