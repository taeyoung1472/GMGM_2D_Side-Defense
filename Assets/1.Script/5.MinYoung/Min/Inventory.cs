using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    #region Singleton
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion


    //public List<ItemInfo> items = new List<ItemInfo>();
    //public Slot[] slots;
    //public int curSlot;
    //public bool isFirst;

    //public bool AddItem(ItemInfo itemInfo)
    //{
    //    if (isFirst)
    //    {
    //        items.Add(itemInfo);
    //        isFirst = false;
    //    }
    //    print("AddItem »£√‚");
    //    if (!slots[curSlot].UpdateItemUI(itemInfo))
    //    {
    //        curSlot++;
    //        items.Add(itemInfo);
    //    }
    //    /*if (items.Count < slotCnt)
    //    {
    //        print("items.Count < slotCnt");
    //        items.Add(itemInfo);
    //        slots[0].UpdateItemUI(itemInfo);
    //        return true;
    //    }*/
    //    print("!items.Count < slotCnt");
    //    return false;
    //}
}
