using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : LivingEntity
{


    SpriteRenderer spriteRenderer;
    PlayerAnimation playerAnimation;

    public void Awake()
    {

        //유니티시간 Time.time은 계속흘러감 
        playerAnimation = GetComponent<PlayerAnimation>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected override void Start()
    {
        base.Start();
    }
    public override void OnDamage(int damage, Vector2 hitPoint, Vector2 normal, float power = 0f, float mineseSpeed = 0f)
    {
        base.OnDamage(damage, hitPoint, normal, power); //피다는거, 힛애니메이션

    }


    protected override IEnumerator hitAnimation(int hitAniCount, float hitAniDelay) //맞을떄 실행
    {
        for(int i = 0; i < hitAniCount; i++)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(hitAniDelay);
            spriteRenderer.color = Color.white;
        }
    }

    protected override void OnDie() //피가 0일떄 실행함
    {
        Debug.Log("플레이어 죽음");
    }
}
