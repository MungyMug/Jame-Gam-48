using UnityEngine;

public class ConeShieldCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
            Debug.Log("Cone hit Shield and was destroyed.");
        }
    }
}
