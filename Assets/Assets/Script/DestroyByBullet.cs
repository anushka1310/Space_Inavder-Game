using UnityEngine;

public class DestroyByBullet : MonoBehaviour, IDestroy
{
    [SerializeField] private int scoreValue;

    public void Kill()
    {
        GameManager.Instance.AddScore(scoreValue);
        AudioManager.Instance.PlayExplosion();
        Destroy(gameObject);
    }
}
