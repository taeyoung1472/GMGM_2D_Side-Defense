using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ִ� ��� ��ü

public abstract class LivingEntity : MonoBehaviour, IDamageable
{
    [Header("ü��")]
    public int maxHP; //�ִ���
    protected int currentHP; // ���� ��
    [Header("���� �´°� �����ؿ�")]
    public Color hitColor; // �÷�
    public int hitAniCount = 3;
    public float hitAniDelay = 0.2f;

    //����� HP����
    [Header("������ ������")]
    public float damageDelay = 0.5f;
    protected float lastDamageTime;
    protected virtual void Start()
    {
        lastDamageTime = Time.time;
        currentHP = maxHP;
    }


    public virtual void OnDamage(int damage, Vector2 hitPoint, Vector2 normal, float power = 0f, float minuesSpeed = 0f) //������ �ӵ��� �������� �Ϸ��µ� 
    {
        if (lastDamageTime + damageDelay > Time.time) return;
        lastDamageTime = Time.time;

        //

        currentHP -= damage;
        StartCoroutine(hitAnimation(hitAniCount, hitAniDelay)); //������ hitAnimation�Լ��� �ϴ°ǰ�?
        if (currentHP <= 0)
        {

            OnDie();
        }
    }



    protected abstract IEnumerator hitAnimation(int hitAniCount, float hitAniDelay);
    protected abstract void OnDie(); //��� ����ü�� ������ �ֱ⿡ ������



}

