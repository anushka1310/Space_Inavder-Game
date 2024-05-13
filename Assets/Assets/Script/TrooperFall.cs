using UnityEngine;

public class TrooperFall : MonoBehaviour
{
    [SerializeField] private float fallSpeed;
    [SerializeField] private LayerMask groundLayer;

    private bool canFall = true;

    private void Update()
    {
        if (!canFall) return;

        if (!Physics2D.Raycast(transform.position, -transform.up, 0.25f, groundLayer))
        {
            Vector2 currentPosition = transform.position;
            currentPosition.y -= fallSpeed * Time.deltaTime;
            transform.position = currentPosition;
        }
        else
        {
            canFall = false;
        }
    }
}
