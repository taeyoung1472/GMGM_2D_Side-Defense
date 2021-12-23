using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeManager : MonoBehaviour
{


    public GrenadeInfo greandeInfo;
    [SerializeField] private GameObject GranadePrefab;


    //�κ��丮�� ����ź�� �ִٸ� ���⿡�� ä����
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
            Debug.Log("������~");
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

        //��ȯ�ϰ� ���󰡴� �ڵ�­���ϱ�



    }

    
}
