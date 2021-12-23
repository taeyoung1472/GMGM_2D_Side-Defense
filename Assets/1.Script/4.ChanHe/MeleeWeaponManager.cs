using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MeleeWeaponManager : MonoBehaviour
{
    [SerializeField] private Transform hand;
    [SerializeField] private MeleeWeaponInfo currentMeleeWeapon;
    [SerializeField] private Text meleeWeaponNameText;

    private void Start()
    {
        StartCoroutine(CheckFire());
        SetUp();
    }

    void SetUp()
    {
        meleeWeaponNameText.text = string.Format("{0}", currentMeleeWeapon.meleeWeaponName);
    }

    public void ChangeWeapon(MeleeWeaponInfo newMeleeWeapon)
    {
        currentMeleeWeapon = newMeleeWeapon;
        SetUp();
    }


    IEnumerator CheckFire()
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));
            Attack();
            yield return new WaitForSeconds(currentMeleeWeapon.attackDelay);

        }
    }

    private void Attack()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * currentMeleeWeapon.range * currentMeleeWeapon.distance, currentMeleeWeapon.range * currentMeleeWeapon.distance);
        Debug.DrawRay(transform.position, transform.right * currentMeleeWeapon.range * currentMeleeWeapon.distance, Color.red, currentMeleeWeapon.attackTime);
        //공격 모션
        if(hit)
        {
            if(hit.transform.CompareTag("Enemy"))
            {
                hit.transform.GetComponent<EnemyBase>().Damaged(currentMeleeWeapon.damage);
                Debug.Log("A");
            }
        }
        transform.DOLocalMoveX(transform.localPosition.x + currentMeleeWeapon.range, currentMeleeWeapon.attackTime).OnComplete(()=>
        {
            transform.DOLocalMoveX(transform.localPosition.x - currentMeleeWeapon.range, 0.1f);
        });
    }
}
