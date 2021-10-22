using UnityEngine;

public class CarTakeDamage : MonoBehaviour
{
    private CarMovement carMovement;

    private void Awake()
    {
        carMovement = GameObject.FindObjectOfType<CarMovement>();
    }

    public void TakeDamage(CarController car, int damage)
    {
        Debug.Log("Vertical speed: " + carMovement.VerticalSpeed);
        Debug.Log("Horizontal speed: " + carMovement.HorizontalSpeed);
        car.Health -= damage;
    }
}
