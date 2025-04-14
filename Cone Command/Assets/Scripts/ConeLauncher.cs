using UnityEngine;

public class ConeLaucher : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private GameObject conePrefab;
    [SerializeField] private Transform startPoint;
    [SerializeField] private float lauchSpeed = 1.0f;
    [SerializeField] private float despawnTimer = 5.0f;
    [SerializeField] private float rotationSpeed = 180.0f;
    public void LaunchCone()
    {
        if (conePrefab != null && startPoint != null)
        {
            Quaternion coneRotation = startPoint.rotation;
            coneRotation.eulerAngles = new Vector3(coneRotation.eulerAngles.x, coneRotation.eulerAngles.y, 180f);
            GameObject spawncone = Instantiate(conePrefab, startPoint.position, startPoint.rotation);

            Rigidbody coneRigidBody = spawncone.GetComponent<Rigidbody>();

            if (coneRigidBody != null)
            {
                coneRigidBody.AddForce(startPoint.forward * lauchSpeed, ForceMode.Impulse);
                coneRigidBody.angularVelocity = new Vector3(rotationSpeed, 0, 0);
            }
            else
            {
                Debug.LogWarning("No Rigid Body");
            }

            Destroy(spawncone, despawnTimer);
        }
    }
}
