using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider enemyHealthSlider;
    public float enemyMaxHealth = 100f;
    public float enemyCurrentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
    }
}
