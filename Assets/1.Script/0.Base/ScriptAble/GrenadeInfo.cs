using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/Grenade", fileName = "GrenadeInfo")]
public class GrenadeInfo : ScriptableObject
{
    public int maxCount; //최대 갯수
    public int currentCount;
    public float damage; //데미지
    public float power; //날라가는 속도
}
