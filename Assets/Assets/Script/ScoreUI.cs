using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

        GameManager.Instance.OnScoreChanged += GameManager_OnScoreChanged;
    }

    private void GameManager_OnScoreChanged(int score)
    {
        scoreText.text = "SCORE: " + score.ToString();
    }
}
