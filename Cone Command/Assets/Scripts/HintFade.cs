using UnityEngine;

public class HintFade : MonoBehaviour
{
    [SerializeField] private float timepast = 0.0f;
    [SerializeField] private float despawntimer = 15.0f;
    void Update()
    {
        timepast = Time.time;
        if(timepast >= despawntimer)
        {
            gameObject.SetActive(false);
        }
    }
}
