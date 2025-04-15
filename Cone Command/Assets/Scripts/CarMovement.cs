using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f;
    [SerializeField] Vector3 moveDirection = Vector3.left;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveSpeed(float updatedSpeed)
    {
        moveSpeed = updatedSpeed;
    }

    public void SetMoveDirection(Vector3 newDirection)
    {
        moveDirection = newDirection;
    }
}
