using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

/// <summary>
/// The script controls player's weapon logic
/// "WeaponController" is a vague name, would probably rename it to something else
/// more descriptive later. 
/// </summary>
internal class PlayerWeaponController : MonoBehaviour, IEquipTarget, IAttacker
{
    [SerializeField] internal Weapon ActiveWeapon;
    private const int LeftClick = 0;
    private const KeyCode PickUpWeapon = KeyCode.F;
    private const KeyCode SwapToBareHands = KeyCode.Alpha1;
    private const KeyCode SwapToPistol = KeyCode.Alpha2;
    private const KeyCode SwapToMachineGun = KeyCode.Alpha3;
    private const float RangeToPickUp = 5f;
    
    private List<Weapon> nonMeleeWeaponsInScene;
    private List<Weapon> ownedWeapons = new List<Weapon>();
    private WeaponDisplay displayActiveWeapon;

    public IEquippable Equippable { get; set; }
    public ITarget Target { get; set; }

    private void Awake()
    {
        displayActiveWeapon = GetComponent<WeaponDisplay>();
    }

    private void Start()
    {
        // Note: Assume there's a default weapon assigned and it's bare hands
        if (ActiveWeapon == null) throw new Exception("Default weapon missing! Please assign a default weapon.");
        ActiveWeapon.EquipTo(this);
        ownedWeapons.Add(ActiveWeapon);
        nonMeleeWeaponsInScene = FindObjectsOfType<Weapon>().Where(w => !(FindObjectOfType<Melee>())).ToList();
    }

    private void Update()
    {
        EquipWeaponIfFound();
        SwapWeaponBasedOnInput();
        FireRangeWeaponWithLeftClick();
    }

    private void FireRangeWeaponWithLeftClick()
    {
        if (Input.GetMouseButtonDown(LeftClick) && ActiveWeapon != null && ActiveWeapon.WeaponName != WeaponName.BareHands)
        {
            ActiveWeapon.GetComponent<FiringWeapon>().Fire();
        }
    }

    private void SwapWeaponBasedOnInput()
    {
        if (ActiveWeapon.WeaponName != WeaponName.BareHands && Input.GetKeyDown(SwapToBareHands))
        {
            ActiveWeapon = ownedWeapons.Find(x => x.name == WeaponName.BareHands);
            Debug.Log("Swap weapon to: " + ActiveWeapon);
            ActiveWeapon.EquipTo(this);
        }
        if (ActiveWeapon.WeaponName != WeaponName.Pistol && ownedWeapons.Find(x => x.WeaponName == WeaponName.Pistol) && Input.GetKeyDown(SwapToPistol))
        {
            ActiveWeapon = ownedWeapons.Find(x => x.name.Contains(WeaponName.Pistol));
            Debug.Log("Swap weapon to: " + ActiveWeapon);
            ActiveWeapon.EquipTo(this);
        }
        if (ActiveWeapon.WeaponName != WeaponName.MachineGun && ownedWeapons.Find(x => x.WeaponName == WeaponName.MachineGun) && Input.GetKeyDown(SwapToMachineGun))
        {
            ActiveWeapon = ownedWeapons.Find(x => x.name.Contains(WeaponName.MachineGun));
            Debug.Log("Swap weapon to: " + ActiveWeapon);
            ActiveWeapon.EquipTo(this);
        }
    }

    private void EquipWeaponIfFound()
    {
        var foundWeapon = weaponIsWithinRange();
        if (foundWeapon != null && Input.GetKeyDown(PickUpWeapon))
        {
            ActiveWeapon = foundWeapon;
            ownedWeapons.Add(ActiveWeapon);
            ActiveWeapon.EquipTo(this);
            ActiveWeapon.gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        if (ActiveWeapon != null) displayActiveWeapon.UpdateWeaponDisplay(ActiveWeapon.WeaponName);
    }

    [CanBeNull]
    private Weapon weaponIsWithinRange()
    {
        Weapon weaponCandidate = null;
        foreach (var weapon in from weapon in nonMeleeWeaponsInScene let find = Vector3.Distance(gameObject.transform.position, weapon.transform.position) <= RangeToPickUp where find select weapon)
        {
            weaponCandidate = weapon;
            break;
        }
        return weaponCandidate;
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
        if (gameObj.CompareTag("Car") && Input.GetMouseButtonDown(LeftClick)) 
        {
            Debug.Log(Equippable);
            Attack(gameObj.GetComponent<CarTakeDamage>());
        }
    }
}
