using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private HandRotation handRotation;
    [SerializeField] private Transform playerPos;

    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private GameObject weaponPrefab;

    [SerializeField] public float minSpawnInterval = 1.0f;
    [SerializeField] public float maxSpawnInterval = 3.0f;
    [SerializeField] public float projectileSpeed = 10f;

    AudioManager audioManager;

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
        if (spawnPoints == null || spawnPoints.Count == 0)
        {
            Debug.LogError("Missing Spawnpoints!");
            enabled = false;
            return;
        }

        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float interval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(interval);

            Attack();
        }
    }

    void Attack()
    {
        EnemyHandRotor();

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        GameObject weapon = Instantiate(weaponPrefab, spawnPoint.position, Quaternion.identity);

        // Tell the weapon where the player is
        WeaponProjectiles wp = weapon.GetComponent<WeaponProjectiles>();
        if (wp != null && playerPos != null)
        {
            wp.Initialize(playerPos.position, projectileSpeed);
        }
        else
        {
            Debug.LogError("WeaponProjectile script or playerPos missing.");
        }
    }

    void EnemyHandRotor()
    {
        if (handRotation != null)
        {
            handRotation.PerformRotation();
            audioManager.PlaySFX(audioManager.enemyattack);
        }
        else
        {
            Debug.LogError("Hand Rotation is not attached!");
        }
    }
}
