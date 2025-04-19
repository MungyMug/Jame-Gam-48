using UnityEngine;

public class ScoreCOunter : MonoBehaviour
{
    public static ScoreCOunter Instance;

    private int carCounter = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterHit(string tag)
    {
        if (tag == "Car")
        {
            carCounter++;
            Debug.Log("Car destroyed! Total: " + carCounter);
        }
        //else if (tag == "Whale")
        //{
        //    whaleCounter++;
        //    Debug.Log("Whale destroyed! Total: " + whaleCounter);
        //}
    }

    public void ShowFinalScore()
    {
        Debug.Log($"Final Score:\nCars: {carCounter}");
    }
}

