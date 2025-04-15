using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    //[SerializeField] private int Health = 10;
    private void OnCollisionEnter(Collision cone)
    {
        if (cone.gameObject.tag == "Cone")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
