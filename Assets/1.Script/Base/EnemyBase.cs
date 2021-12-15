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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Object"))
        {
            Attack(collision.gameObject.GetComponent<Object_>());
            StartCoroutine(Attack());
        }
        if (collision.transform.CompareTag("Player"))
        {
            Attack(collision.gameObject.GetComponent<Player>());
            StartCoroutine(Attack());
        }
    }
    virtual protected void Attack(Object_ _obj)
    {
        _obj.GetDamage(damage);
    }
    virtual protected void Attack(Player player)
    {
        player.GetDamage(damage);
    }
    virtual protected IEnumerator Attack()
    {
        speed = -enemyInfo.hitSpeed;
        yield return new WaitForSeconds(1f);
        speed = enemyInfo.speed;
    }
    virtual protected IEnumerator Damaged()
    {
        speed = enemyInfo.hitSpeed;
        sprite.color = Color.red;
        yield return new WaitForSeconds(enemyInfo.shockTime);
        sprite.color = Color.white;
        speed = enemyInfo.speed;
    }
    virtual protected void Dead()
    {
        Destroy(gameObject);
    }
}