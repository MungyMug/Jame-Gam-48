using UnityEngine;

public class HintFade : MonoBehaviour
{
    [SerializeField] private float despawnTimer = 15.0f;
    private float timePassed = 0.0f;

    void OnEnable()
    {
        timePassed = 0.0f;
    }

    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= despawnTimer)
        {
            gameObject.SetActive(false);
        }
    }
}

