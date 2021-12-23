using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class EnemyBase : MonoBehaviour, IDamageable
{
    [Header("이승훈 작업본")]
    [SerializeField] private float attackDealy, lastAttackTime = 0;
    [SerializeField] private bool isAttack = false, isType2;
    [Header("이태영 작업본")]
    [SerializeField] protected EnemyInfo enemyInfo;
    protected float currentHp, damage, speed;
    protected SpriteRenderer sprite;
    protected Rigidbody2D rb;
    public void Start()
    {
        currentHp = enemyInfo.hp;
        damage = enemyInfo.damage;
        speed = enemyInfo.speed;
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    virtual protected void Update()
    {
        Move();
        if (!isType2)
        {
            AttackType2();
        }
    }
    virtual protected void Move()
    {
        rb.velocity = new Vector2(-speed, rb.velocity.y);
    }
    public void Damaged(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            OnDie();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            Damaged(collision.GetComponent<BulletMove>().GetDamage());
            collision.GetComponent<BulletMove>().Penetration();
            if(currentHp <= 0)
            {
                OnDie();
            }
            StartCoroutine(hitAnimation(enemyInfo.hitAniCount,enemyInfo.shockTime, enemyInfo.hitColor));
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isType2)
        {
            if (collision.gameObject.CompareTag("Object"))
            {
                Attack(collision.gameObject.GetComponent<ObjectBase>());
                StartCoroutine(AttackEffect());
            }
            if (collision.gameObject.CompareTag("Player"))
            {
                Attack(collision.gameObject.GetComponent<Player>());
                StartCoroutine(AttackEffect());
            }
        }
    }
    virtual protected void AttackType2()
    {
        if (isAttack)
        {
            if (lastAttackTime + attackDealy <= Time.time) //딜레이가 끝나 다시 공격가능하다면
            {
                lastAttackTime = Time.time;
                AttackEffect();
            }
        }
    }
    virtual protected void Attack(ObjectBase obj)
    {
        obj.GetDamage(enemyInfo.damage);
    }
    virtual protected void Attack(Player player)
    {
        player.GetDamage(enemyInfo.damage);
    }
    virtual protected IEnumerator AttackEffect()
    {
        speed = -enemyInfo.backSpeed;
        yield return new WaitForSeconds(enemyInfo.backTime);
        speed = enemyInfo.speed;
    }
    protected abstract IEnumerator hitAnimation(int hitAniCount, float hitAniDelay, Color hitClor);
    protected abstract void OnDie(); //모든 생명체는 죽음이 있기에 다형성
    public void OnDamage(float damage, Vector2 normal = default, float Power = 0, float minuseSpeed = 0)
    {
        currentHp -= damage;
        if(currentHp <= 0)
        {
            OnDie();
        }
    }
    #region 더미
    /*speed = enemyInfo.hitSpeed;
for (int i = 0; i < hitAniCount; i++)
{
    sprite.color = Color.red;
    yield return new WaitForSeconds(enemyInfo.shockTime / hitAniCount);
    sprite.color = Color.white;
}
speed = enemyInfo.speed;*/
    #endregion
}