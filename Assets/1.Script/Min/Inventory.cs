//    using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Inventory : MonoBehaviour
//{
//    public static Inventory instance;
//    #region Singleton
//    private void Awake()
//    {
//        if (instance != null)
//        {
//            Destroy(gameObject);
//            return;
//        }
//        instance = this;
//    }
//    #endregion
//    public delegate void OnSlotCountChange(int val);
//    public OnSlotCountChange onSlotCountChange;

//    public delegate void OnChangeItem();
//    public OnChangeItem onChangeItem;
//    public List<ItemInfo> items = new List<ItemInfo>();
//    private int slotCnt;
//    public int SlotCnt
//    {
//        get => slotCnt;
//        set
//        {
//            slotCnt = value;
//            onSlotCountChange.Invoke(SlotCnt);
//        }
//    }
//    private void Start()
//    {
//        SlotCnt = 4;
//    }
//    public bool AddItem(ItemInfo itemInfo)
//    {
//        if (items.Count <SlotCnt)
//        {
//            items.Add(itemInfo);
         
//            onChangeItem.Invoke();
//            return true;
//        }
//        return false;

//    }
//}
