using UnityEngine;
using UnityEngine.UI;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealthBar enemyHealthBar;
    [SerializeField] private float healthminus = 2.0f;

    private void OnCollisionEnter(Collision cone)
    {
        if (cone.gameObject.tag == "Cone")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            enemyHealthBar.enemyCurrentHealth -= healthminus;
            Destroy(cone.gameObject);

            ScoreCOunter.Instance?.RegisterHit("Car");
        }
    }
}
