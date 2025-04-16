using UnityEngine;

public class PlayerBoundaries : MonoBehaviour
{
    [SerializeField] float leftBoundary = -8.0f;
    [SerializeField] float rightBoundary = 8.0f;

    public void BoundaryCheck(GameObject Player)
    {
        if (Player == null) return;

        if (Player.transform.position.x < leftBoundary)
        {
            Player.transform.position = new Vector3(leftBoundary, Player.transform.position.y, Player.transform.position.z);
        }
        else if (Player.transform.position.x > rightBoundary)
        {
            Player.transform.position = new Vector3(rightBoundary, Player.transform.position.y, Player.transform.position.z);
        }
    }
}
