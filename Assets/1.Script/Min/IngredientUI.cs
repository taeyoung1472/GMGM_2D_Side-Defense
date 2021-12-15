using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientUI : MonoBehaviour
{
    public GameObject craftingList; //재료 리스트

    public void ShowCraftingList()
    {
        craftingList.SetActive(true);
    } 
    public void DownCraftingList()
    {
        craftingList.SetActive(false);
    }


}
