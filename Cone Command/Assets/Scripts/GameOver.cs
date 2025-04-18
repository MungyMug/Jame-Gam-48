using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameOver : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}