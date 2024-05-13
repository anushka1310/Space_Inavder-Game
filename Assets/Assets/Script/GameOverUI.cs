using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private TextMeshProUGUI scoreText; 
    [SerializeField] private Button restartBtn;
    [SerializeField] private Button quitBtn;

    private int score;

    private void Start()
    {
        gameOverMenu.SetActive(false);

        restartBtn.onClick.AddListener(() => SceneManager.LoadScene(1));
        quitBtn.onClick.AddListener(QuitGame); 
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;
        GameManager.Instance.OnScoreChanged += GameManager_OnScoreChanged;
    }

    private void GameManager_OnScoreChanged(int newScore)
    {
        score = newScore;
    }

    private void GameManager_OnGameOver()
    {
        Invoke("GameOver", 3f);
    }

    private void GameOver()
    {
        gameOverMenu.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
        AudioManager.Instance.GameOverSfx();
    }

    private void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
        #else
        Application.Quit(); // Quit the application in built version
        #endif
    }
}
