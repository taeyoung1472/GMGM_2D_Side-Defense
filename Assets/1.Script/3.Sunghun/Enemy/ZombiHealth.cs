using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiHealth : LivingEntity
{

    /*Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    public EnemyInfo EnemyInfo;

    protected override void Start()
    {
        base.Start();
        currentHP = EnemyInfo.hp;
    }


    protected void Awake()
    {

        print(currentHP);
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void OnDamage(float damage, Vector2 normal, float Power = 0f, float minuseSpeed = 0f)
    {
        base.OnDamage(damage, normal, Power ,  minuseSpeed);

        Debug.Log("원데미지 실행");
        rigid.velocity -=  new Vector2(minuseSpeed, 0f) ;
    }

    protected override IEnumerator hitAnimation(int hitAniCount, float hitAniDelay)
    {
        for(int i = 0; i < hitAniCount; i++)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(hitAniDelay);
            spriteRenderer.color = Color.white;
        }
    }

    protected override void OnDie()
    {
        gameObject.SetActive(false);
    }*/
}
