using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTroopManager : MonoBehaviour
{
    private const string TROOPER_LAYER = "Trooper";

    public static GroundTroopManager Instance;

    private Stack<Trooper> leftTroopers;
    private Stack<Trooper> rightTroopers;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        leftTroopers = new Stack<Trooper>();
        rightTroopers = new Stack<Trooper>();
    }

    public void AddtoLeftStack(Trooper trooper)
    {
        if (leftTroopers.Count >= 4) return;

        leftTroopers.Push(trooper);

        if (leftTroopers.Count >= 4)
        {
            GameManager.Instance.TriggerEnemyStopSpawn();
            StartCoroutine(LeftTroopersAttack());
        }
    }

    public void AddtoRightStack(Trooper trooper)
    {
        if (rightTroopers.Count >= 4) return;

        rightTroopers.Push(trooper);

        if (rightTroopers.Count >= 4)
        {
            GameManager.Instance.TriggerEnemyStopSpawn();
            StartCoroutine(RightTroopersAttack());
        }
    }

    private IEnumerator LeftTroopersAttack()
    {
        for (int i = 0; i < 4; i++)
        {
            Trooper trooper = leftTroopers.Pop();
            trooper.gameObject.layer = LayerMask.NameToLayer(TROOPER_LAYER);

            trooper.MoveInDirection(Direction.Right);
            yield return new WaitForSeconds(3f);
        }
    }

    private IEnumerator RightTroopersAttack()
    {
        for (int i = 0; i < 4; i++)
        {
            Trooper trooper = rightTroopers.Pop();
            trooper.gameObject.layer = LayerMask.NameToLayer(TROOPER_LAYER);

            trooper.MoveInDirection(Direction.Left);
            yield return new WaitForSeconds(3f);
        }
    }
}
