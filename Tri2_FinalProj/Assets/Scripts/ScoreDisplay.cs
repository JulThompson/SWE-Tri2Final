using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TMP_Text scoreText;

    void Start()
    {
        int finalScore = ScoreManager.Instance.GetScore();
        
        if (scoreText != null)
        {
            scoreText.text = "Score: " + finalScore;
        }
        else
        {
            Debug.LogError("scoreText is not assigned in the inspector!");
        }
    }
}
