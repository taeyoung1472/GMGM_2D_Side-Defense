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
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
