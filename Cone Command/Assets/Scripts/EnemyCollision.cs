using UnityEngine;
using UnityEngine.UI;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealthBar enemyHealthBar;
    [SerializeField] private float healthminus = 2.0f;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found in the scene.");
        }
    }
    private void OnCollisionEnter(Collision cone)
    {
        if (cone.gameObject.tag == "Cone")
        {
            audioManager.PlaySFX(audioManager.enemyhit);
            //GetComponent<MeshRenderer>().material.color = Color.red;
            enemyHealthBar.enemyCurrentHealth -= healthminus;
            Destroy(cone.gameObject);

            ScoreCOunter.Instance?.RegisterHit("Car");
        }
    }
}
