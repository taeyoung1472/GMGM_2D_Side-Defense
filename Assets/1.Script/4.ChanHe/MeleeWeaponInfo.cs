using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/MeleeWeapon", fileName = "MeleeWeaponInfo")]
public class MeleeWeaponInfo : ScriptableObject
{
    public string meleeWeaponName;
    public string desc;
    public float damage;
    public float attackDelay, attackTime; //attackDelay 공격 후 딜레이 시간 //attackTime 공격 시간
    public Sprite meleeWeaponSprite; //근접 무기 스프라이트 
    public float range;
    public float distance;
}
