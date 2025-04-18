using UnityEngine;

public class Phase2Launch : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 playerpostition = Vector3.zero;

    [SerializeField] EnemyHealthBar enemyHp;
    [SerializeField] float phase2health = 70.0f;

    [SerializeField] float projectileSpeed = 1.0f;
    void Awake()
    {
        gameObject.SetActive(false);
    }
    void Start()
    {
        playerpostition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHp.enemyCurrentHealth <= phase2health)
        {
            gameObject.SetActive(true);
        }

        MoveToPlayer();
        DestroyWhenReach();
    }

    void DestroyWhenReach()
    {
        if (transform.position == playerpostition)
        {
            Destroy(gameObject);
        }
    }

    void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerpostition, projectileSpeed * Time.deltaTime);
    }
}
