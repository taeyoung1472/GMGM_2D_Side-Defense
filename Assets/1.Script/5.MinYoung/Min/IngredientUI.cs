using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientUI : MonoBehaviour
{
    public GameObject craftingList; //��� ����Ʈ

    public void ShowCraftingList()
    {
        craftingList.SetActive(true);
    } 
    public void DownCraftingList()
    {
        craftingList.SetActive(false);
    }


}
