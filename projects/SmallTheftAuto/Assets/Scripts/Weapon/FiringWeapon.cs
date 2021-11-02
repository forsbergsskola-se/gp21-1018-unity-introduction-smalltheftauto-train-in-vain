using UnityEngine;

public class FiringWeapon : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;

    internal void Fire()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var bullet = Instantiate(Bullet);
    }
}
