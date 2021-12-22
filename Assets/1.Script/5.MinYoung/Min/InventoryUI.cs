using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    [SerializeField] private GameObject inventoryPanelSlot;
    private List<PanelBase> inventoryPanels = new List<PanelBase>();

    [SerializeField]
    private GameObject inventoryPanel;
    private bool isActiveInventory = false;
    [SerializeField] private Inventory inventory;   
    void Start()
    {
        InstantiatePanel();
        inventoryPanel.SetActive(isActiveInventory);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isActiveInventory = !isActiveInventory;
            inventoryPanel.SetActive(isActiveInventory);
        }
    }
    public void InstantiatePanel()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject obj = Instantiate(inventoryPanelSlot, inventoryPanelSlot.transform.parent);
            //inventory.slots[i] = obj.GetComponent<Slot>();
            PanelBase panel = obj.GetComponent<PanelBase>();

            inventoryPanels.Add(panel);
            Debug.Log("AS");
        }
        inventoryPanelSlot.SetActive(false);

    }

}
