using UnityEngine;
[CreateAssetMenu(menuName = "ScriptableObject/Enemy", fileName = "EnemyInfo")]
public class EnemyInfo : ScriptableObject
{
    public string enemyName;
    public string desc;
    public int hitAniCount = 3;
    public Color hitColor = Color.red;
    public float hp, damage, speed, hitSpeed, shockTime, backSpeed, backTime;
    public EnemyMode enemyMode;
    public enum EnemyMode
    {
        basic,
        fly
    }
}