using UnityEngine;

internal class Weapon : MonoBehaviour, IEquippable
{
    [SerializeField] private string WeaponName;
    [SerializeField] public WeaponPower Power;
    public IEquipTarget EquippedTo { get; private set; }
    public void UnEquip()
    {
        EquippedTo.Equippable = null;
        EquippedTo = null;
    }

    public void EquipTo(IEquipTarget equipTarget)
    {
        equipTarget.Equippable?.UnEquip();
        equipTarget.Equippable = this;
        EquippedTo = equipTarget;
    }

    public override string ToString() => WeaponName;
}
