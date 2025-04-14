using Unity.Android.Gradle.Manifest;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private ConeLaucher conelauncher;
    [SerializeField] private float spawnTimer = 0.5f;

    private float lastspawntime = 0.0f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastspawntime + spawnTimer)
        {
            LaunchCone();
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
}
