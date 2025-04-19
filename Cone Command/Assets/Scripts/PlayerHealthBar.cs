using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider playerHealthSlider;
    public float playerMaxHealth = 5f;
    public float playerCurrentHealth;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHealthSlider.value != playerCurrentHealth)
        {
            playerHealthSlider.value = playerCurrentHealth;
        }
    }

    public void TakeDamage()
    {
        playerCurrentHealth -= 1f;
        if (playerCurrentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
