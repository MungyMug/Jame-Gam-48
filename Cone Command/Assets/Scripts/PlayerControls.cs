using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private ConeLaucher conelauncher;
    [SerializeField] private float spawnTimer = 0.5f;
    [SerializeField] private HandRotation handRotation;
    [SerializeField] private HandRotation bodyRotation;
    [SerializeField] private GameObject shield;

    private float lastspawntime = 0.0f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastspawntime + spawnTimer)
        {
            if (!shield.activeSelf) {
                LaunchCone();
                HandRotor();
                BodyRotor();
            }
            lastspawntime = Time.time;
        }
    }

    void LaunchCone()
    {
        if (conelauncher != null)
        {
            conelauncher.LaunchCone();
        }
        else
        {
            Debug.LogError("Cone Launcher is not attached!");
        }
    }

    void HandRotor()
    {
        if (handRotation != null)
        {
            handRotation.PerformRotation();
        }
        else
        {
            Debug.LogError("Hand Rotation is not attached!");
        }
    }

    void BodyRotor()
    {
        if (bodyRotation != null)
        {
            bodyRotation.PerformRotation();
        }
        else
        {
            Debug.LogError("Body Rotation is not attached!");
        }
    }
}
