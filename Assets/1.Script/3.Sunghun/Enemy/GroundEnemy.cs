using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : EnemyMove
{

    Vector2 moveDir;
    protected override void Awake()
    {
        base.Awake();
    }
    private Vector3 spriteSize;

    private void Start()
    {
        moveDir = transform.right * -1;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        spriteSize = sr.bounds.size;
    }



    private void Update()
    {


        if(moveSet)
        {
            rigid.velocity = new Vector2(moveDir.x * currentSpeed * GameManager.TimeScale, rigid.velocity.y);
        }

        
    }
}
