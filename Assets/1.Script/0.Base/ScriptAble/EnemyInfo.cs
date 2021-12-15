using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/Enemy", fileName = "EnemyInfo")]
public class EnemyInfo : ScriptableObject
{
    public string enemyName;
    public string desc;
    public float hp, damage, speed, hitSpeed, shockTime, backSpeed, backTime;
    public EnemyMode enemyMode;
    public enum EnemyMode
    {
        basic,
        fly
    }
}
