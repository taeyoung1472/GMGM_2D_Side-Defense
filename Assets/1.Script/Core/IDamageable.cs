using UnityEngine;

//�̰� �����ϱ����� �������̽��� 
public interface IDamageable
{
    void OnDamage(int damage, Vector2 hitPoint, Vector2 normal, float power = 0f , float minuseSpeed = 0f);
    //������, ���� ����Ʈ, ���� ����Ʈ, ���� ��, �Ǵٴ°�, ������ �̵��ӵ�����
}
