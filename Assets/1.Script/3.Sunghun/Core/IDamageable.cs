using UnityEngine;

//�̰� �����ϱ����� �������̽��� 
public interface IDamageable
{

    void OnDamage(float damage, Vector2 normal = default(Vector2), float Power = 0f, float minuseSpeed = 0f);
    //������, ���� ����Ʈ, ���� ����Ʈ, ���� ��, �Ǵٴ°�, ������ �̵��ӵ�����
}
