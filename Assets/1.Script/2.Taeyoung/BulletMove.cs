using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : PoolingBase
{
    [SerializeField] private BulletInfo bulletInfo;
    [SerializeField] private Vector2 maxDistance;
    int penetrationChance;

    public LayerMask WhoisEnemy;
    float damage;
    float power;
    float minuseSpeed;
    public void Start()
    {
        SetPool();
        penetrationChance = bulletInfo.penetrationChance;
        damage = bulletInfo.damage;
        power = bulletInfo.power;
        minuseSpeed = bulletInfo.minuseSpeed;
    }
    public void Update()
    {
        Move();
    }
    void Move()
    {
        transform.Translate(Vector2.right * bulletInfo.speed * Time.deltaTime);
    }
    public void Penetration()
    {
        penetrationChance--;
        damage *= bulletInfo.penetrationPerDamage;
        if (penetrationChance <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    public float GetDamage() { return damage; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & WhoisEnemy) > 0)
        {


            IDamageable hp = collision.gameObject.GetComponent<IDamageable>();


            if (hp != null)
            {


                hp.OnDamage(damage, Vector2.right, power, minuseSpeed);

                gameObject.SetActive(false);

            }

        }
    }

   
}
