using UnityEngine;

internal abstract class Weapon : ScriptableObject, IEquippable
{
    private string weaponName;
    public WeaponPower Power { get; }
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

    protected Weapon(string name, WeaponPower power)
    {
        weaponName = name;
        Power = power;
    }

    public override string ToString() => name;
}

internal enum WeaponPower
{
    Weak = 20,
    Medium = 50,
    Strong = 80
}
