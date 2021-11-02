using UnityEngine;

public class FiringWeapon : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;

    internal void Fire()
    {
        Instantiate(Bullet);
    }
}
