using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5.0f; // Use a single variable for speed for simplicity
    [SerializeField] Vector3 moveDirection = Vector3.left; // Set the direction of movement

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
}
