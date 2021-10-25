using UnityEngine;

/// <summary>
/// The script controls player's weapon logic
/// "WeaponController" is a vague name, would probably rename it to something else
/// more descriptive later.
/// </summary>
internal class PlayerWeaponController : MonoBehaviour, IEquipTarget
{
    // WARNING temporary for developement purpose
    private const KeyCode AttackKey = KeyCode.Space;
    // WARNING
    private Weapon bareHands;
    public IEquippable Equippable { get; set; }

    private void Awake()
    {
        // Player equip Bare hands by default
        bareHands = ScriptableObject.CreateInstance<WeaponBareHands>();
        bareHands.EquipTo(this);
    }

    void Update()
    {
        if (Input.GetKeyDown(AttackKey))
        {
            Debug.Log($"Player attacks with {bareHands} that deals {(int)bareHands.Power} damage.");
        }
    }
}
