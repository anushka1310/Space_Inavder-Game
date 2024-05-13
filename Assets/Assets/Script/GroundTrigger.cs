using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    [SerializeField] private Direction side;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Trooper trooper))
        {
            switch (side)
            {
                case Direction.Left:
                    GroundTroopManager.Instance.AddtoLeftStack(trooper); 
                    break;
                case Direction.Right:
                    GroundTroopManager.Instance.AddtoRightStack(trooper); 
                    break;
            }
        }
    }
}
