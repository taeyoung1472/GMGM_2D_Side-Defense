using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject Sprite;

    public ParticleSystem efftect;
    public LayerMask WhatIsEnemy;
    public Rigidbody2D rigid;



    public int damage = 0;
    public float power = 0;

    public bool EnemyTouch = true;
    
    IEnumerator GrenadeExPlosion()
    {
        yield return new WaitForSeconds(1.5f);

        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = 0f;
        efftect.Play();
        Sprite.SetActive(false);

        RaycastHit2D[] rayhit = Physics2D.CircleCastAll(transform.position, 4f, Vector2.up, 0f, WhatIsEnemy);

        foreach(RaycastHit2D hit in rayhit)
        {
            IDamageable hp = hit.transform.GetComponent<IDamageable>();

            if(hp != null)
            {
                Debug.Log("Àû´ê¾Ò´Ù.");
                hp.OnDamage(damage, Vector2.right, power);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((1 << collision.gameObject.layer & WhatIsEnemy) > 0)
        {

            if(EnemyTouch)
            {
                EnemyTouch = false;
                rigid.velocity = rigid.velocity * 0.1f;
                rigid.angularVelocity = 0f;
                Debug.Log("Æø¹ß ¿¹¼ú");
                StartCoroutine(GrenadeExPlosion());
            }
         


        }
    }


}
