using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : EnemyMove
{

    public EnemyInfo zombieInfo;
    Vector2 moveDir;
    protected override void Awake()
    {
        base.Awake();
        currentSpeed = zombieInfo.speed;
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

    public override void SetMove()
    {
        isChase = false;
        moveSet = true;
        currentSpeed = zombieInfo.speed;
    }

}
