using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float shootDelay;

    private bool canShoot = true;
    private float timer;

    private void Start()
    {
        InputManager.Instance.OnPlayerShoot += InputManager_OnPlayerShoot;
    }

    private void Update()
    {
        if (canShoot) return;

        timer += Time.deltaTime;

        if (timer > shootDelay)
        {
            canShoot = true;
            timer = 0;
        }
    }

    private void OnDisable()
    {
        InputManager.Instance.OnPlayerShoot -= InputManager_OnPlayerShoot;
    }

    private void InputManager_OnPlayerShoot()
    {
        if (!canShoot) return;

        GameObject spawnedBullet = Instantiate(bulletPrefab);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.transform.up = spawnPoint.up;
        AudioManager.Instance.PlayShoot();
        canShoot = false;
    }
}
