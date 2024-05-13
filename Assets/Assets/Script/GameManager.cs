using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public event Action<int> OnScoreChanged;
    public event Action<int> OnDifficultyChanged;
    public event Action OnEnemyStopSpawn;
    public event Action OnGameOver;

    [SerializeField] private List<int> targetScoresList;

    private int score;
    private int difficulty;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void TriggerEnemyStopSpawn()
    {
        OnEnemyStopSpawn?.Invoke();
    }

    public void TriggerGameOver()
    {
        OnGameOver?.Invoke();
    }

    public void AddScore(int value)
    {
        score += value;
        OnScoreChanged?.Invoke(score);

        if (difficulty < targetScoresList.Count && score > targetScoresList[difficulty])
        {
            difficulty++;
            OnDifficultyChanged?.Invoke(difficulty);
        }
    }
}
