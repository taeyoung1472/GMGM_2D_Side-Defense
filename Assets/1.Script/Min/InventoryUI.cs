using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //Inventory inven;
    public GameObject inventoryPanel;
    private bool isActiveInventory = false;
    public Slot[] slots;
    public Transform slotHolder;
    void Start()
    {
        //inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();
    //    inven.onSlotCountChange += SlotChange;
       // inven.onChangeItem += RewardSlotUI;
        inventoryPanel.SetActive(isActiveInventory);
    }
    //private void SlotChange(int val)
    //{
    //    for (int i = 0; i < slots.Length; i++)
    //    {
    //        if (i < inven.SlotCnt)
    //        {
    //            slots[i].GetComponent<Button>().interactable = true;
    //        }
    //        else
    //        {
    //            slots[i].GetComponent<Button>().interactable = false;
    //        }
    //    }
    //}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isActiveInventory = !isActiveInventory;
            inventoryPanel.SetActive(isActiveInventory);
        }
    }
    public void AddSlot()
    {
        //inven.SlotCnt++;
    }
    //void RewardSlotUI()
    //{
    //    for (int i = 0; i < slots.Length; i++)
    //    {
    //        slots.RemoveSlot();
    //    }
    //    for (int i = 0; i < inven.items.Count; i++)
    //    {
    //        slots[i].item = inven.items[i];
    //        slots[i].UpdateSlotUI();
    //    }
    //}
}
