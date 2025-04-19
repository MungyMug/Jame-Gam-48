using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider enemyHealthSlider;
    public float enemyMaxHealth = 100f;
    public float enemyCurrentHealth;

    // This part is for phase2
    public float phase2HealthThreshold = 70f;
    public float retreatSpeed = 5f;
    private bool phase2Triggered = false;

    [SerializeField] private GameObject enemy;
    [SerializeField] Vector3 moveDirection = Vector3.forward;

    [SerializeField] private GameObject WaterStage;
    [SerializeField] private GameObject P2Weapons;

    [SerializeField] private float phase3HealthThreshold = 50f;
    [SerializeField] private float phase4HealthThreshold = 20f;

    AudioManager audioManager;

    private float honkTimer;

    public float minHonkInterval = 5f;
    public float maxHonkInterval = 10f;

    public float minVolume = 0.5f;
    public float maxVolume = 1.0f;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found in the scene.");
        }
    }
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        SetRandomHonkTimer();
    }

    void Update()
    {
        honkTimer -= Time.deltaTime;

        if (honkTimer <= 0f)
        {
            float randomVolume = Random.Range(minVolume, maxVolume);
            audioManager.PlaySFX(audioManager.carhonk, randomVolume);

            SetRandomHonkTimer();
        }

        if (enemyHealthSlider.value != enemyCurrentHealth)
        {
            enemyHealthSlider.value = enemyCurrentHealth;
        }

        if (!phase2Triggered && enemyCurrentHealth <= phase2HealthThreshold)
        {
            if(enemy.transform.position.z <= -13.0f)
            {
                TriggerPhase2();
            }
            else
            {
                audioManager.PlaySFX(audioManager.whalesplash);
                audioManager.PlaySFX(audioManager.whalesound);
                phase2Triggered = true;
            }
        }

        if (phase2Triggered)
        {
            BeginPhase2();
        }

        if(enemyCurrentHealth <= phase3HealthThreshold)
        {
            ChangeMovement();
        }

        if (enemyCurrentHealth <= phase4HealthThreshold)
        {
            ChangeAttack1();
        }

        if (enemyCurrentHealth <= 0f)
        {
            SceneManager.LoadScene("GameWin");
        }
    }

    void BeginPhase2()
    {
        WaterStage.SetActive(true);
        ChangeAttack();
        Debug.Log("Enemy has entered Phase 2! Change attack patterns, enable new behavior, etc.");
    }

    void TriggerPhase2()
    {
        enemy.transform.position += moveDirection * retreatSpeed * Time.deltaTime;
        Debug.Log("Phase 2 triggered. Retreating...");
    }

    void ChangeAttack()
    {
        EnemyAttack enemyAttack = enemy.GetComponent<EnemyAttack>();
        enemyAttack.minSpawnInterval = 1f;
        enemyAttack.maxSpawnInterval = 2f;
        enemyAttack.projectileSpeed = 15f;
    }

    void ChangeAttack1()
    {
        EnemyAttack enemyAttack = enemy.GetComponent<EnemyAttack>();
        enemyAttack.minSpawnInterval = 1f;
        enemyAttack.maxSpawnInterval = 1f;
        enemyAttack.projectileSpeed = 23f;
    }

    void ChangeMovement()
    {
        EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
        enemyMovement.minSpeed = 7f;
        enemyMovement.maxSpeed = 12f;
    }

    void SetRandomHonkTimer()
    {
        honkTimer = Random.Range(minHonkInterval, maxHonkInterval);
    }
}
