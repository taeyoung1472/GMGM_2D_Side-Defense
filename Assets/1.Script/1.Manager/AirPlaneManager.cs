using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirPlaneManager : MonoBehaviour
{

    private bool isSupply = true; //true = 보급 진행 , false = 진행 X 
    private bool isDropSupply = false; // true = 보급 공급 , false = X
    private bool isSupplyEnd = false; // true = 보급 공급 , false = X

    [SerializeField] private float speed = 10f;

    [SerializeField] GameObject suppliesPrefab; //보급품

    public void SetIsSupply(bool isSupply) //이 함수를 참으로 넣으면 출발함
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

    public void DropSupply() //보급이 생성됨
    {
        GameObject  a = Instantiate(suppliesPrefab, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), transform.rotation);
        isDropSupply = false;
    }
}
