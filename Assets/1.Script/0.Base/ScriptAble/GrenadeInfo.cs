using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/Grenade", fileName = "GrenadeInfo")]
public class GrenadeInfo : ScriptableObject
{
    public int maxCount; //�ִ� ����
    public int currentCount;
    public float damage; //������
    public float power; //���󰡴� �ӵ�
}
