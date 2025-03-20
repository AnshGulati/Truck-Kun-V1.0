using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Playerfinal>().ActivateShield(); // Activate shield
            Destroy(gameObject); // Remove power-up
        }
    }
}