using UnityEngine;

public class WeaponProjectiles : MonoBehaviour
{
    private Vector3 targetPosition;
    private float speed = 10f;
    private bool initialized = false;

    public void Initialize(Vector3 target, float projectileSpeed)
    {
        targetPosition = target;
        speed = projectileSpeed;
        initialized = true;
    }

    void Update()
    {
        if (!initialized) return;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }
}
