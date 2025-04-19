using UnityEngine;

public class ConeShieldCollision : MonoBehaviour
{
    AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found in the scene.");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shield"))
        {
            audioManager.PlaySFX(audioManager.block);
            Destroy(gameObject);
            Debug.Log("Cone hit Shield and was destroyed.");
        }
    }
}
