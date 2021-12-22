using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/MeleeWeapon", fileName = "MeleeWeaponInfo")]
public class MeleeWeaponInfo : ScriptableObject
{
    public string meleeWeaponName;
    public string desc;
    public float damage;
    public float attackDelay, attackTime; //attackDelay ���� �� ������ �ð� //attackTime ���� �ð�
    public Sprite meleeWeaponSprite; //���� ���� ��������Ʈ 
    public float range;
    public float distance;
}
