using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject blastEffect;

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition += bulletSpeed * Time.deltaTime * transform.up;
        transform.position = currentPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDestroy destructible))
        {
            destructible.Kill();
            GameObject blast = Instantiate(blastEffect);
            blast.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
