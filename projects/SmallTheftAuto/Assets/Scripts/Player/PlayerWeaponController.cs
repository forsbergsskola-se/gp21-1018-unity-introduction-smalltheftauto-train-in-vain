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
    [SerializeField] private float RangeToPickUp;
    
    private List<Weapon> nonMeleeWeaponsInScene;
    private List<Weapon> ownedWeapons = new List<Weapon>();
    private WeaponDisplay displayActiveWeapon;
    private PlayerMovement playerMovement;
    private List<GameObject> punchTargets = new List<GameObject>();

    public IEquippable Equippable { get; set; }
    public ITarget Target { get; set; }

    private void Awake()
    {
        displayActiveWeapon = GetComponent<WeaponDisplay>();
        playerMovement = GetComponent<PlayerMovement>();
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
        ReloadRangeWeaponWithR();
        MeleeAttack();
    }

    private void SwapWeaponBasedOnInput()
    {
        if (ActiveWeapon.WeaponName != WeaponName.BareHands && Input.GetKeyDown(KeyBinding.SwapToBareHands))
        {
            ActiveWeapon = ownedWeapons.Find(x => x.name == WeaponName.BareHands);
            Debug.Log("Swap weapon to: " + ActiveWeapon);
            ActiveWeapon.EquipTo(this);
        }
        if (ActiveWeapon.WeaponName != WeaponName.Pistol && ownedWeapons.Find(x => x.WeaponName == WeaponName.Pistol) && Input.GetKeyDown(KeyBinding.SwapToPistol))
        {
            ActiveWeapon = ownedWeapons.Find(x => x.name.Contains(WeaponName.Pistol));
            Debug.Log("Swap weapon to: " + ActiveWeapon);
            ActiveWeapon.EquipTo(this);
            ActiveWeapon.GetComponent<FiringWeapon>().UpdateRemainBulletDisplay();
        }
        if (ActiveWeapon.WeaponName != WeaponName.MachineGun && ownedWeapons.Find(x => x.WeaponName == WeaponName.MachineGun) && Input.GetKeyDown(KeyBinding.SwapToMachineGun))
        {
            ActiveWeapon = ownedWeapons.Find(x => x.name.Contains(WeaponName.MachineGun));
            Debug.Log("Swap weapon to: " + ActiveWeapon);
            ActiveWeapon.EquipTo(this);
            ActiveWeapon.GetComponent<FiringWeapon>().UpdateRemainBulletDisplay();
        }
    }

    private void EquipWeaponIfFound()
    {
        var foundWeapon = weaponIsWithinRange();
        if (foundWeapon != null && Input.GetKeyDown(KeyBinding.PickUpWeapon))
        {
            ActiveWeapon = foundWeapon;
            ownedWeapons.Add(ActiveWeapon);
            ActiveWeapon.EquipTo(this);
            ActiveWeapon.gameObject.SetActive(false);
            ActiveWeapon.GetComponent<FiringWeapon>().UpdateRemainBulletDisplay();
        }
    }
    
    private void FireRangeWeaponWithLeftClick()
    {
        if (Input.GetButtonDown(KeyBinding.FireWeapon) && ActiveWeapon && ActiveWeapon.WeaponName != WeaponName.BareHands)
        {
            var firingWeapon = ActiveWeapon.GetComponent<FiringWeapon>();
            if (firingWeapon.totalRounds <= 0) return;
            playerMovement.isShooting = true;
            firingWeapon.Fire();
        }
    }
    
    private void ReloadRangeWeaponWithR()
    {
        if (Input.GetKeyDown(KeyBinding.ReloadWeapon) && ActiveWeapon && ActiveWeapon.WeaponName != WeaponName.BareHands)
        {
            ActiveWeapon.GetComponent<FiringWeapon>().Reload();
        }
    }
    
    private void MeleeAttack()
    {
        if (ActiveWeapon.WeaponName == WeaponName.BareHands && Input.GetButtonDown(KeyBinding.FireWeapon) && canPunch())
        {
            foreach (var t in punchTargets)
            {
                if (t == null)
                {
                    punchTargets.Remove(t);
                    break;
                }
                if (t.TryGetComponent(out IDamageable iDamageable)) iDamageable.TakeDamage((int)ActiveWeapon.Power, t);
            }
        }
    }

    private void LateUpdate()
    {
        displayActiveWeapon.UpdateWeaponDisplay(ActiveWeapon.WeaponName);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        punchTargets.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other != null) punchTargets.Remove(other.gameObject);
        Debug.Log("Length of punchable things: " + punchTargets.Count);
    }

    private bool canPunch() => punchTargets.Count > 0;
}
