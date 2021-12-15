using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneManager : MonoBehaviour
{

    private bool isSupply = true; //true = ���� ���� , false = ���� X 
    private bool isDropSupply = false; // true = ���� ���� , false = X
    private bool isSupplyEnd = false; // true = ���� ���� , false = X

    [SerializeField] private float speed = 10f;

    [SerializeField] GameObject suppliesPrefab; //����ǰ

    public void SetIsSupply(bool isSupply) //�� �Լ��� ������ ������ �����
    {
        this.isSupply = isSupply;
    }

    private void Update()
    {
        if (!isSupply) return;
        gameObject.transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);

        if (gameObject.transform.position.x <= 2f && !isSupplyEnd)
            isDropSupply = true;
        else if (gameObject.transform.position.x <= -35f)
        {
            isSupply = false;
            isDropSupply = false;
            isSupplyEnd = false;
            gameObject.transform.position = new Vector2(55f, 4f);
        }
        if (isDropSupply)
        {
            isSupplyEnd = true;
            DropSupply();
        }
    }

    public void DropSupply() //������ ������
    {
        GameObject  a = Instantiate(suppliesPrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), transform.rotation);
        isDropSupply = false;
    }
}
