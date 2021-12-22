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
            Debug.Log(itemInfo + "재료를 만들었어요");
            //Inventory.instance.AddItem(itemInfo);
        }
        else
        {
            Debug.Log("재료가부족합니다");
            return;//못만들때 실행문
        }
    }
}