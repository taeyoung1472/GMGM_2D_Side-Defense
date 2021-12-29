using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFOV : MonoBehaviour
{
    /*public float viewRange = 10f; //�þ߰Ÿ�
    [Range(0, 360)]
    public float viewAngle = 40f; //�þ߰���
    public float attackRange = 1f; //���ݰŸ�

    public LayerMask obstacleLayer; //��ֹ� ���� 
    private int playerLayer;

    private EnemyMove enemyMove; // �� ���� ��������� �˱���� �ڤä�����Ʈ

    private void Awake()
    {
        enemyMove = GetComponent<EnemyMove>();
        playerLayer = LayerMask.NameToLayer("PLAYER"); //���̾� ���� �˷���
    }

    public Vector2 CirclePoint(float angle)
    {
        if (enemyMove != null)
        {
            angle += enemyMove.GetFront().x < 0 ? -90f : 90f;
        }
        else
        {
            angle += 90f;
        }

        return new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), Mathf.Cos(angle * Mathf.Deg2Rad));
    }

    public bool IsTracePlayer()
    {
        bool isTrace = false;
        Collider2D col = Physics2D.OverlapCircle(transform.position, viewAngle, 1 << playerLayer);

        if (col != null && enemyMove != null)
        {
            // z�� �ʿ������ ���� 2�� ��ȯ��Ŵ
            Vector2 dir = GameManager.Player.position - transform.position;

            if (Vector2.Angle(enemyMove.GetFront(), dir) < viewAngle * 0.5f)
            {

                isTrace = true;
            }
        }

        return isTrace;
    }

    public bool IsViewPlayer()
    {
        bool isView = false;
        Vector2 dir = GameManager.Player.position - transform.position;
        RaycastHit2D hit2D = Physics2D.Raycast
            (transform.position, dir.normalized, viewRange, obstacleLayer);

        if (hit2D.collider != null)
        {
            isView = (hit2D.collider.gameObject.CompareTag("Player"));
        }

        return isView;
    }

    public bool IsAttackPossible()
    {
        return (GameManager.Player.position - transform.position).sqrMagnitude
            <= Mathf.Pow(attackRange, 2);
    }

    */
}
