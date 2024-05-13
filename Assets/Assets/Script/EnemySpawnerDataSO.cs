using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Enemy Spawner Data", fileName = "new Enemy Spawner Data")]
public class EnemySpawnerDataSO : ScriptableObject
{
    public List<GameObject> EnemyPrefab;
    public float SpawnDelay;
}
