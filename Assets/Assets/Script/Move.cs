using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        currentPosition += moveSpeed * Time.deltaTime * transform.right;
        transform.position = currentPosition;
    }
}
