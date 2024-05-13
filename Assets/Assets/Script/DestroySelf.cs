using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] private float lifetime;

    private void OnEnable()
    {
        Destroy(gameObject, lifetime);
    }
}
