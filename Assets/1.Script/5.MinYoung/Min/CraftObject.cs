using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftObject : MonoBehaviour
{
    public CraftInfo craftInfo;
    public ItemInfo itemInfo;
    InventoryUI iu;
    
    private void Awake()
    {
        iu = FindObjectOfType<InventoryUI>();
    }
    public void SetInfo(CraftInfo info , ItemInfo item)
    {
        craftInfo = info;
        itemInfo = item;
    }
    public void Craft()
    {
        if 
        (
        GameManager.Instance.CurrentUser.wood >= craftInfo.namu &&
        GameManager.Instance.CurrentUser.gunpowder >= craftInfo.hwayack &&
        GameManager.Instance.CurrentUser.iron >= craftInfo.chul
        
        )
        {
            GameManager.Instance.CurrentUser.wood -= craftInfo.namu;
            GameManager.Instance.CurrentUser.gunpowder -= craftInfo.hwayack;
            GameManager.Instance.CurrentUser.iron -= craftInfo.chul;
            Debug.Log(itemInfo + "��Ḧ ��������");
            //Inventory.instance.AddItem(itemInfo);
        }
        else
        {
            Debug.Log("��ᰡ�����մϴ�");
            return;//�����鶧 ���๮
        }
    }
}