using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{
    private void Update()
    {
        Move();
    }
    void Move()
    {
        rb.velocity = new Vector2(-speed,rb.velocity.y);
    }
}
