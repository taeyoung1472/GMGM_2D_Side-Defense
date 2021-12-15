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

    private void Start()
    {
        moveDir = transform.right * -1;
    }


    private void Update()
    {
        if(moveSet)
        {
            rigid.velocity = new Vector2(moveDir.x * currentSpeed * GameManager.TimeScale, rigid.velocity.y);
        }
    }
}
