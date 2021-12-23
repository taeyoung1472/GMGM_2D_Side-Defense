using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : LivingEntity
{


    SpriteRenderer spriteRenderer;
    PlayerAnimation playerAnimation;

    public void Awake()
    {

        //����Ƽ�ð� Time.time�� ����귯�� 
        playerAnimation = GetComponent<PlayerAnimation>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected override void Start()
    {
        base.Start();
    }
    public override void OnDamage(float damage, Vector2 normal, float Power = 0f, float minuseSpeed = 0f)
    {
        base.OnDamage(damage,  normal, Power,  minuseSpeed ); //�Ǵٴ°�, ���ִϸ��̼�

    }


    protected override IEnumerator hitAnimation(int hitAniCount, float hitAniDelay) //������ ����
    {
        for(int i = 0; i < hitAniCount; i++)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(hitAniDelay);
            spriteRenderer.color = Color.white;
        }
    }

    protected override void OnDie() //�ǰ� 0�ϋ� ������
    {
        Debug.Log("�÷��̾� ����");
    }
}
