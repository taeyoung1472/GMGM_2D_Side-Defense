using UnityEngine;

//이거 구현하기위해 인터페이스로 
public interface IDamageable
{

    void OnDamage(float damage, Vector2 normal = default(Vector2), float Power = 0f, float minuseSpeed = 0f);
    //데미지, 맞은 포인트, 날라갈 포인트, 날라갈 힘, 피다는거, 맞을때 이동속도감소
}
