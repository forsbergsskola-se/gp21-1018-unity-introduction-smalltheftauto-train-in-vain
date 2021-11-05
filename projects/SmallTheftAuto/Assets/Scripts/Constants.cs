using UnityEngine;

internal enum WeaponPower
{
    Weak = 20,
    Medium = 50,
    Strong = 80
}

internal class WeaponName
{
    internal const string BareHands = "BareHands";
    internal const string Pistol = "Pistol";
    internal const string MachineGun = "MachineGun";
}

internal class KeyBinding : MonoBehaviour
{
    internal const string PlayerAttack = "Fire1";
    internal const KeyCode PickUpWeapon = KeyCode.F;
    internal const KeyCode ReloadWeapon = KeyCode.R;
    internal const KeyCode SwapToBareHands = KeyCode.Alpha1;
    internal const KeyCode SwapToPistol = KeyCode.Alpha2;
    internal const KeyCode SwapToMachineGun = KeyCode.Alpha3;
}
