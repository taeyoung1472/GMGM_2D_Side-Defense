using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Bullet", fileName = "BulletInfo")]
public class BulletInfo : ScriptableObject
{
    public string BulletName;
    public string desc;
    public float speed;
    public float damage;
    public float power;
    public float minuseSpeed;
    public int penetrationChance;
    public float penetrationPerDamage;
}