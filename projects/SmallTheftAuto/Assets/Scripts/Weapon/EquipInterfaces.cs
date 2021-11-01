internal interface IEquippable
{
    // private WeaponPower Power { get; }
    public IEquipTarget EquippedTo { get; }
    public void EquipTo(IEquipTarget equipTarget);
    public void UnEquip();
}

internal interface IEquipTarget
{
    public  IEquippable Equippable { get; set; }
}
