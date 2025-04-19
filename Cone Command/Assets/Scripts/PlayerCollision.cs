using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerHealthBar playerHealthBar;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found in the scene.");
        }
    }
    private void OnCollisionEnter(Collision weapon)
    {
        if (weapon.gameObject.CompareTag("EnemyWeapon"))
        {
            Collider weaponCollider = weapon.gameObject.GetComponent<Collider>();
            if (weaponCollider != null && weaponCollider.enabled)
            {
                Debug.Log("Player hit by enemy weapon");
                audioManager.PlaySFX(audioManager.playerhit);
                playerHealthBar.TakeDamage();

                weaponCollider.enabled = false;
                Destroy(weapon.gameObject);
            }
        }
    }
}
