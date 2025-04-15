using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class ConeCollision : MonoBehaviour
{
    [SerializeField] private float upwardSpeed = 1.0f;
    [SerializeField] private float explosionForce = 10.0f;
    [SerializeField] private MonoBehaviour CarMovementScript;

    [SerializeField] private int points = 1;

    private ScoreManager scoreManager;
    //private CarSpawner spawner;

    private void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
        if(scoreManager == null)
        {
            Debug.LogError("ScoreManager not found!");
        }

        //CarSpawner = FindObjectOfType<CarSpawner>();
    }
    private void OnCollisionEnter(Collision cone)
    {
        if (cone.gameObject.tag == "Cone")
        {
            //GetComponent<MeshRenderer>().material.color = Color.red;
            Debug.Log("Collision Detected!");

            if(scoreManager != null && gameObject.tag != "Hit")
            {
                scoreManager.IncreaseScore(points);
            }

            gameObject.tag = "Hit";

            Rigidbody carRb = GetComponent<Rigidbody>();
            BoxCollider carBC = GetComponent<BoxCollider>();

            if (carRb != null)
            {
                Vector3 explosionDirection = Random.onUnitSphere;
                explosionDirection.y = Mathf.Abs(explosionDirection.y) * upwardSpeed;

                carRb.AddForce(explosionDirection * explosionForce, ForceMode.Impulse);

                if (carBC != null)
                {
                    carBC.enabled = false;
                }

                if (CarMovementScript != null)
                {
                    CarMovementScript.enabled = false;
                }
            }
        }
    }
}
