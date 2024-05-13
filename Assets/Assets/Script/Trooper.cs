using UnityEngine;

public enum Direction
{
    Left,
    Right
}

public enum TrooperState
{
    Idle,
    Move
}

public class Trooper : MonoBehaviour
{
    private const string TROOPER_LAYER = "Trooper";
    private const string TURRET_LAYER= "Turret";
    private const float TROOPER_HEIGHT = 0.5f;

    [SerializeField] private GameObject blastEffect;
    [SerializeField] private Transform leftCheck;
    [SerializeField] private Transform rightCheck;
    [SerializeField] private Transform topLeftCheck;
    [SerializeField] private Transform topRightCheck;
    [SerializeField] private float moveSpeed; 

    private TrooperState state;
    private Direction direction;
    private bool canMove = true;

    private void Start()
    {
        state = TrooperState.Idle;
    }

    private void Update()
    {
        if (!canMove) return;

        switch (state)
        {
            case TrooperState.Idle:
                break;
            case TrooperState.Move:
                Move();
                break;
        }
    }

    public void MoveInDirection(Direction direction)
    {
        this.direction = direction;
        state = TrooperState.Move;
    }

    private void Move()
    {
        switch (direction)
        {
            case Direction.Left:
                MoveLeft();
                break;

            case Direction.Right:
                MoveRight();
                break;

            default:
                break;
        }
    }

    private void MoveLeft()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(leftCheck.position, -transform.right, 0.001f);
        RaycastHit2D topRaycastHit2D = Physics2D.Raycast(topLeftCheck.position, -transform.right, 0.001f);

        if (topRaycastHit2D && topRaycastHit2D.collider.gameObject.layer == LayerMask.NameToLayer(TROOPER_LAYER))
        {
            canMove = false;
            return;
        }

        if (!raycastHit2D || raycastHit2D.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x -= moveSpeed * Time.deltaTime;
            transform.position = currentPosition;
        }
        else if (raycastHit2D.collider.gameObject.layer == LayerMask.NameToLayer(TROOPER_LAYER))
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y += TROOPER_HEIGHT + 0.01f;
            transform.position = currentPosition;
        }
        else if (raycastHit2D.collider.gameObject.layer == LayerMask.NameToLayer(TURRET_LAYER))
        {
            canMove = false;
        }
    }

    private void MoveRight()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(rightCheck.position, transform.right, 0.001f);
        RaycastHit2D topRaycastHit2D = Physics2D.Raycast(topRightCheck.position, transform.right, 0.001f);

        if (topRaycastHit2D && topRaycastHit2D.collider.gameObject.layer == LayerMask.NameToLayer(TROOPER_LAYER))
        {
            canMove = false;
            return;
        }

        if (!raycastHit2D || raycastHit2D.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x += moveSpeed * Time.deltaTime;
            transform.position = currentPosition;
        }
        else if (raycastHit2D.collider.gameObject.layer == LayerMask.NameToLayer(TROOPER_LAYER))
        {
            Vector3 currentPosition = transform.position;
            currentPosition.y += TROOPER_HEIGHT + 0.01f;
            transform.position = currentPosition;
        }
        else if (raycastHit2D.collider.gameObject.layer == LayerMask.NameToLayer(TURRET_LAYER))
        {
            canMove = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IDestroyByEnemy destructibleByEnemy))
        {
            destructibleByEnemy.Kill();
            AudioManager.Instance.PlayExplosion();
            GameObject blast = Instantiate(blastEffect);
            blast.transform.position = transform.position;
        }
    }
}