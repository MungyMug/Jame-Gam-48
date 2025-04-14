using Unity.Cinemachine;
using UnityEngine;

public class ConeCollision : MonoBehaviour
{
    [SerializeField] private float upwardSpeed = 1.0f;
    [SerializeField] private float explosionForce = 10.0f;
    [SerializeField] private MonoBehaviour CarMovementScript; 
    private void OnCollisionEnter(Collision cone)
    {
        if (cone.gameObject.tag == "Cone")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Hit";
            Debug.Log("Collision Detected!");

            Rigidbody carRb = GetComponent<Rigidbody>();

            if (carRb != null)
            {
                Vector3 explosionDirection = Random.onUnitSphere;
                explosionDirection.y = Mathf.Abs(explosionDirection.y) * upwardSpeed;

                carRb.AddForce(explosionDirection * explosionForce, ForceMode.Impulse);

                if (CarMovementScript != null)
                {
                    CarMovementScript.enabled = false;
                }
            }
        }
    }
}
