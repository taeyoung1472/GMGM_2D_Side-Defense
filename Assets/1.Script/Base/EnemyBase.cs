using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyBase : MonoBehaviour
{
    protected float hp, damage, speed;
    protected SpriteRenderer sprite;
    [SerializeField] protected EnemyInfo enemyInfo;
    private void Start()
    {
        hp = enemyInfo.hp;
        damage = enemyInfo.damage;
        speed = enemyInfo.speed;
        sprite = GetComponent<SpriteRenderer>();
    }
    public void Damaged(float damage)
    {
        hp -= damage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
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
}