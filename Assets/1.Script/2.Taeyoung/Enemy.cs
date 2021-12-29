using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : EnemyBase
{
    protected override IEnumerator hitAnimation(int hitAniCount, float hitAniDelay, Color hitColor)
    {
        speed = enemyInfo.hitSpeed;
        for (int i = 0; i < hitAniCount; i++)
        {
            sprite.color = hitColor;
            yield return new WaitForSeconds(hitAniDelay / hitAniCount);
            sprite.color = Color.white;
        }
        speed = enemyInfo.speed;
    }

    protected override void OnDie()
    {
        Destroy(gameObject);
    }
}