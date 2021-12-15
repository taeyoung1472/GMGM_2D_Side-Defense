using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBase : MonoBehaviour
{
    protected float hp, damage, speed;
    protected SpriteRenderer sprite;
    protected Rigidbody2D rb;
    [SerializeField] protected EnemyInfo enemyInfo;
    virtual protected void Start()
    {
        SetUp();
    }
    virtual protected void SetUp()
    {
        hp = enemyInfo.hp;
        damage = enemyInfo.damage;
        speed = enemyInfo.speed;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    virtual protected void Damaged(float damage)
    {
        hp -= damage;
    }
    virtual protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            Damaged(collision.GetComponent<BulletMove>().GetDamage());
            collision.GetComponent<BulletMove>().Penetration();
            if(hp <= 0)
            {
                Dead();
            }
            StartCoroutine(Damaged());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.transform.CompareTag("Object"))
        {

        }*/
    }
    virtual protected IEnumerator Damaged()
    {
        speed = enemyInfo.hitSpeed;
        sprite.color = Color.red;
        yield return new WaitForSeconds(enemyInfo.shockTime);
        sprite.color = Color.white;
        speed = enemyInfo.speed;
    }
    virtual protected void Attack()
    {

    }
    virtual protected void Dead()
    {
        Destroy(gameObject);
    }
}