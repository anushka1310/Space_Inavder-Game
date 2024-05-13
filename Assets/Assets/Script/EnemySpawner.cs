using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPointArray;
    [SerializeField] private EnemySpawnerDataSO[] enemySpawnerDataSOArray;

	private bool shouldSpawn;
    private int difficulty;

    private void Start()
    {
        shouldSpawn = true;

        StartCoroutine(StartSpawning());

        GameManager.Instance.OnDifficultyChanged += GameManager_OnDifficultyChanged;
        GameManager.Instance.OnEnemyStopSpawn += GameManager_OnEnemyStopSpawn;
    }

    private void GameManager_OnEnemyStopSpawn()
    {
        shouldSpawn = false;
    }

    private void GameManager_OnDifficultyChanged(int newDifficulty)
    {
        difficulty = newDifficulty;
    }

    private IEnumerator StartSpawning()
    {
        while (shouldSpawn)
        {
            yield return new WaitForSeconds(enemySpawnerDataSOArray[difficulty].SpawnDelay);

            GameObject enemyToSpawn = enemySpawnerDataSOArray[difficulty].EnemyPrefab[Random.Range(0, enemySpawnerDataSOArray[difficulty].EnemyPrefab.Count)];

            Spawn(enemyToSpawn);
        }
    }

    private void Spawn(GameObject enemyToSpawn)
    {
        Transform spawnPoint = spawnPointArray[Random.Range(0, spawnPointArray.Length)];

        GameObject spawnedObject = Instantiate(enemyToSpawn);
        spawnedObject.transform.position = spawnPoint.position;
        spawnedObject.transform.right = spawnPoint.right;
    }
}
