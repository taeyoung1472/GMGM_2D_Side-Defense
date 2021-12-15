using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftObject : MonoBehaviour
{
    public CraftInfo craftInfo;
    public ItemInfo itemInfo;
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
            Debug.Log("재료를 만들었어요");
            //GameManager.Inventory.AddItem(ItemInfo);// 대충 이런 함수
        }
        else
        {
            Debug.Log("재료가부족합니다");
            return;//못만들때 실행문
        }
    }
}