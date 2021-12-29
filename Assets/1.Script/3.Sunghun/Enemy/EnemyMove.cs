using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    protected SpriteRenderer spriteRenderer;
    public bool facingRight = true; // 오른쪽 보고 있는감

    public float judgeDistance = 0.1f;

    
   // public float patrolDistance = 1.5f;
    public float currentSpeed;

    protected bool isChase = false;

    protected Vector2 destination;
    protected bool moveSet = false;
    protected Rigidbody2D rigid;


    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    public Vector2 GetFront()
    {
        
        if (facingRight)
        {
            return transform.localScale.x > 0 ? transform.right : transform.right * -1;
        }
        else
        {
            return transform.localScale.x > 0 ? transform.right * -1 : transform.right;
        }
    }

    public virtual void Stop()
    {
        rigid.velocity = Vector2.zero;
        moveSet = false;
    }

    public virtual void SetChase(Vector2 target)
    {
        destination = target;
        isChase = true;
        moveSet = true;
    }

    public virtual void SetMove()
    {
        isChase = false;
        moveSet = true;
    }
    
    public void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    
}
