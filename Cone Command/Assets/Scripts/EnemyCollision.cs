using UnityEngine;
using UnityEngine.UI;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealthBar enemyHealthBar;

    private void OnCollisionEnter(Collision cone)
    {
        if (cone.gameObject.tag == "Cone")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            enemyHealthBar.enemyCurrentHealth -= 1f;
        }
    }
}
