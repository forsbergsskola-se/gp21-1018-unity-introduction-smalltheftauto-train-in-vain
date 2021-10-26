using UnityEngine;

/// <summary>
/// The script controls player's weapon logic
/// "WeaponController" is a vague name, would probably rename it to something else
/// more descriptive later.
/// </summary>
internal class PlayerWeaponController : MonoBehaviour, IEquipTarget, IAttacker
{
    private const int LeftClick = 0;
    private Weapon bareHands;
    
    public IEquippable Equippable { get; set; }
    public ITarget Target { get; set; }

    private void Awake()
    {
        // Player equip Bare hands by default
        bareHands = gameObject.AddComponent<WeaponBareHands>();
        bareHands.EquipTo(this);
    }

    public void Attack(ITarget target, int damage)
    {
        Target = target;
        Target.TakeDamage(damage);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        var gameObj = other.gameObject;
        Debug.Log("HEY AM FROM PlayerWeaponController");
        if (gameObj.CompareTag("Car") && Input.GetMouseButtonDown(LeftClick))
        {
            Debug.Log(Equippable);
            Attack(gameObj.GetComponent<CarTakeDamage>(), (int)Equippable.Power);
        }
    }
}
