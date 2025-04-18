using UnityEngine;

public class Shield1 : MonoBehaviour
{
    [SerializeField] private GameObject shield;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
    }
}
