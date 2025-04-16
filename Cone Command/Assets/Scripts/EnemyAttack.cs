using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform attackOrigin;
    [SerializeField] private float launchSpeed = 10f;
    [SerializeField] private float minAttackInterval = 1f;
    [SerializeField] private float maxAttackInterval = 3f;
    [SerializeField] private float projectileLifespan = 5f;
    [SerializeField] private float aimOffsetY = 0f;

    [SerializeField] private HandRotation handRotation;

    private Transform playerTransform;
    private float timeSinceLastAttack = 0f;
    private float currentAttackInterval;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player not found with tag 'Player'.");
            enabled = false;
        }

        if (attackOrigin == null)
        {
            attackOrigin = transform;
            Debug.LogWarning("Attack Origin not set. Using enemy's transform.");
        }

        SetRandomAttackInterval();
    }

    void Update()
    {
        if (playerTransform == null) return;

        timeSinceLastAttack += Time.deltaTime;

        if (timeSinceLastAttack >= currentAttackInterval)
        {
            Attack();
            timeSinceLastAttack = 0f;
            SetRandomAttackInterval();
        }
    }

    void Attack()
    {
        EnemyHandRotor();
        if (projectilePrefab != null && attackOrigin != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, attackOrigin.position, attackOrigin.rotation);
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

            if (projectileRb != null)
            {
                Vector3 targetPosition = playerTransform.position + Vector3.up * aimOffsetY;
                Vector3 launchDirection = (targetPosition - attackOrigin.position).normalized;
                projectileRb.AddForce(launchDirection * launchSpeed, ForceMode.Impulse);
            }
            else
            {
                Debug.LogWarning("Projectile prefab does not have a Rigidbody.");
            }

            Destroy(projectile, projectileLifespan);
        }
        else
        {
            Debug.LogError("Projectile Prefab or Attack Origin is not set.");
        }
    }

    void SetRandomAttackInterval()
    {
        currentAttackInterval = Random.Range(minAttackInterval, maxAttackInterval);
    }

    void EnemyHandRotor()
    {
        if (handRotation != null)
        {
            handRotation.PerformRotation();
        }
        else
        {
            Debug.LogError("Hand Rotation is not attached!");
        }
    }
}
