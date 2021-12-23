using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeManager : MonoBehaviour
{


    public GrenadeInfo greandeInfo;
    [SerializeField] private GameObject GranadePrefab;


    //인벤토리에 수류탄이 있다면 여기에서 채워줌
    public float angular;

    private void Awake()
    {
        currentGrenadeCount = greandeInfo.maxCount;
    }
    

    public int maxGrenadeCount = 3;
    public int currentGrenadeCount = 3;


    private void Update()
    {
        if (Input.GetKey(KeyCode.T) && Input.GetMouseButtonDown(0) && currentGrenadeCount > 0)
        {
            Debug.Log("던질게~");
            Grenade();
        }
    }
     

public void Grenade()
    {
        currentGrenadeCount--;
        Vector2 mouseVector = Input.mousePosition;
        mouseVector = Camera.main.ScreenToWorldPoint(mouseVector);

        GameObject granadeObj = Instantiate(GranadePrefab, transform.position, Quaternion.identity);
        Vector2 nextVec = mouseVector - (Vector2)transform.position;
        print(nextVec);
        Rigidbody2D grenadeRigid = granadeObj.GetComponent<Rigidbody2D>();
        grenadeRigid.AddForce(nextVec.normalized * 15, ForceMode2D.Impulse);
        grenadeRigid.AddTorque(angular, ForceMode2D.Impulse);

        //소환하고 날라가는 코드짯으니까



    }

    
}
