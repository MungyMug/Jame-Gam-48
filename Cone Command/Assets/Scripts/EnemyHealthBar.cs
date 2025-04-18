using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider enemyHealthSlider;
    public float enemyMaxHealth = 100f;
    public float enemyCurrentHealth;

    // This part is for phase2
    public float phase2HealthThreshold = 80f;
    public float retreatSpeed = 5f;
    private bool phase2Triggered = false;

    [SerializeField] private GameObject enemy;
    [SerializeField] Vector3 moveDirection = Vector3.forward;

    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealthSlider.value != enemyCurrentHealth)
        {
            enemyHealthSlider.value = enemyCurrentHealth;
        }

        if (!phase2Triggered && enemyCurrentHealth <= phase2HealthThreshold)
        {
            TriggerPhase2();
        }

    }

    void BeginPhase2()
    {
        Debug.Log("Enemy has entered Phase 2! Change attack patterns, enable new behavior, etc.");
    }

    void TriggerPhase2()
    {
        phase2Triggered = true;

        while(enemy.transform.position.z <= -13.0f)
        {
            enemy.transform.position += moveDirection * retreatSpeed * Time.deltaTime;
        }

        Debug.Log("Phase 2 triggered. Retreating...");
    }
}
