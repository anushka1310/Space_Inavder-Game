using System.Collections;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn;
    [SerializeField] private Transform spawnPoint; 
    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    private void OnEnable()
    {
        StartCoroutine(DropEnemy());
    }

    private IEnumerator DropEnemy()
    {
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPoint.position, Quaternion.identity);
    }
}
