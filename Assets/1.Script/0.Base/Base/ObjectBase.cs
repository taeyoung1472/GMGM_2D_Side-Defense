using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
    [SerializeField] protected float hp;
    public virtual void GetDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Break();
        }
    }
    public virtual void Break()
    {
        Destroy(gameObject);
    }
}
