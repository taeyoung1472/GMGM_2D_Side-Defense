using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour, IDamageable
{
    bool isBreak;
    private SpriteRenderer sprite;
    private Collider2D collider;
    [SerializeField] protected float hp;
    protected virtual void Start()
    {
        collider = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    public virtual void GetDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            Break();
            isBreak = true;
            return;
        }
        StartCoroutine(Attacked());
    }
    protected virtual IEnumerator Attacked()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        if (!isBreak)
        {
            sprite.color = Color.white;
        }
    }
    protected virtual void Break()
    {
        sprite.color = Color.gray;
        collider.enabled = false;
    }

    public void OnDamage(float damage, Vector2 normal, float Power = 0, float minuseSpeed = 0)
    {
        throw new System.NotImplementedException();
    }
}
