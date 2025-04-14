using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;
    void Start()
    {
        if (scoreText == null)
        {
            Debug.LogError("Score TMP is not assigned.");
        }
        UpdateScoreText();
    }

    // Update is called once per frame
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void IncreaseScore(int points)
    {
        score += points;
        UpdateScoreText();
    }
}
