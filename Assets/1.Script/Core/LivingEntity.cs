using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//살아있는 모든 객체

public abstract class LivingEntity : MonoBehaviour, IDamageable
{
    [Header("체력")]
    public int maxHP; //최대피
    protected int currentHP; // 현재 피
    [Header("나는 맞는걸 좋아해요")]
    public Color hitColor; // 컬러
    public int hitAniCount = 3;
    public float hitAniDelay = 0.2f;

    //여기는 HP관련
    [Header("데미지 딜레이")]
    public float damageDelay = 0.5f;
    protected float lastDamageTime;
    protected virtual void Start()
    {
        lastDamageTime = Time.time;
        currentHP = maxHP;
    }


    public virtual void OnDamage(int damage, Vector2 hitPoint, Vector2 normal, float power = 0f, float minuesSpeed = 0f) //맞으면 속도가 느려지게 하려는데 
    {
        if (lastDamageTime + damageDelay > Time.time) return;
        lastDamageTime = Time.time;

        //

        currentHP -= damage;
        StartCoroutine(hitAnimation(hitAniCount, hitAniDelay)); //그적의 hitAnimation함수를 하는건가?
        if (currentHP <= 0)
        {

            OnDie();
        }
    }



    protected abstract IEnumerator hitAnimation(int hitAniCount, float hitAniDelay);
    protected abstract void OnDie(); //모든 생명체는 죽음이 있기에 다형성



}

