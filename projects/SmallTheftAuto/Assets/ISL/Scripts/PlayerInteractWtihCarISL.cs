using UnityEngine;

public class PlayerInteractWtihCarISL : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D other)
    {
        //  && Input.GetKeyDown(KeyCode.E)
        if (other.gameObject.CompareTag("Car") && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
            Debug.Log("nooooooooooooo");
        }
    }
}
