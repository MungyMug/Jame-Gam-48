using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private PlayerBoundaries boundaries;

    void Start()
    {
        
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3 (horizontalInput, 0.0f, 0.0f) * moveSpeed * Time.deltaTime;
        transform.Translate (movement);
        boundaries.BoundaryCheck(gameObject);
    }
}
