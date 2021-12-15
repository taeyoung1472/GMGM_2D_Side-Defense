using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public CraftObject co;
    public Image itemIcon;
    public void UpdUpdateSlotUI()
    {
        itemIcon.sprite = co.craftInfo.profileSprite;
        itemIcon.gameObject.SetActive(true);
    }
    public void RemoveSlot()
    {
        co = null;
        itemIcon.gameObject.SetActive(false);
    }
}
