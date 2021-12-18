using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBase : MonoBehaviour
{
    protected float hp, damage, speed;
    protected SpriteRenderer sprite;
    protected Rigidbody2D rb;
    [SerializeField] protected EnemyInfo enemyInfo;
    public void Start()
    {
        hp = enemyInfo.hp;
        damage = enemyInfo.damage;
        speed = enemyInfo.speed;
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    virtual protected void Update()
    {
        Move();
    }
    virtual protected void Move()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
    public void Damaged(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Dead();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
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
        if (collision.gameObject.CompareTag("Object"))
        {
            Attack(collision.gameObject.GetComponent<ObjectBase>());
            StartCoroutine(Attack());
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Attack(collision.gameObject.GetComponent<Player>());
            StartCoroutine(Attack());
        }
    }
    private IEnumerator Damaged()
    {
        speed = enemyInfo.hitSpeed;
        sprite.color = Color.red;
        yield return new WaitForSeconds(enemyInfo.shockTime);
        sprite.color = Color.white;
        speed = enemyInfo.speed;
    }
    private void Dead()
    {
        Destroy(gameObject);
    }
    virtual protected void Attack(ObjectBase obj)
    {
        obj.GetDamage(enemyInfo.damage);
    }
    virtual protected void Attack(Player player)
    {
        player.GetDamage(enemyInfo.damage);
    }
    virtual protected IEnumerator Attack()
    {
        speed = -enemyInfo.backSpeed;
        yield return new WaitForSeconds(enemyInfo.backTime);
        speed = enemyInfo.speed;
    }
}