using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiHealth : LivingEntity
{

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    protected override void Start()
    {
        base.Start();
    }


    protected void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void OnDamage(int damage, Vector2 hitPoint, Vector2 normal, float power = 0, float minuesSpeed = 0)
    {
        base.OnDamage(damage, hitPoint, normal, power, minuesSpeed);

        Debug.Log("원데미지 실행");
        rigid.velocity -=  new Vector2(minuesSpeed,0f) ;
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
    }
}
