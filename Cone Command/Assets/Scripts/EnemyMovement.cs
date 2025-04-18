using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] public float minSpeed = 1f;
    [SerializeField] public float maxSpeed = 3f;
    [SerializeField] private float changeDirectionInterval = 2f;
    [SerializeField] private float directionChangeProbability = 0.3f;

    [SerializeField] private float leftBoundary = -10f;
    [SerializeField] private float rightBoundary = 10f;

    private float currentSpeed;
    private Vector3 moveDirection = Vector3.right;
    private float timeSinceLastDirectionChange = 0f;
    void Start()
    {
        SetRandomSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * currentSpeed * Time.deltaTime);

        if (transform.position.x <= leftBoundary)
        {
            moveDirection = Vector3.right;
            SetRandomSpeed();
        }
        else if (transform.position.x >= rightBoundary)
        {
            moveDirection = Vector3.left;
            SetRandomSpeed();
        }
        else
        {
            timeSinceLastDirectionChange += Time.deltaTime;

            if (timeSinceLastDirectionChange >= changeDirectionInterval)
            {
                timeSinceLastDirectionChange = 0f;

                if (Random.value < directionChangeProbability)
                {
                    moveDirection = Random.value < 0.5f ? Vector3.left : Vector3.right;
                    SetRandomSpeed();
                }
            }
        }
    }

    void SetRandomSpeed()
    {
        currentSpeed = Random.Range(minSpeed, maxSpeed);
    }
}
