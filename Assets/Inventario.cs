// File name: InventoryManager

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<SlotsInv> inventorySlots;
    public Transform inventoryPanel;
    private bool isInventoryOpen = false;

    private void Start()
    {
        InitializeInventory();
        inventoryPanel.gameObject.SetActive(isInventoryOpen); // Initialize the inventory as closed
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
    }

    private void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventoryPanel.gameObject.SetActive(isInventoryOpen);
    }

    private void InitializeInventory()
    {
        // Instead of instantiating, we find the slots that already exist in the panel
        foreach (Transform slotTransform in inventoryPanel)
        {
            SlotsInv slotComponent = slotTransform.GetComponent<SlotsInv>();
            if (slotComponent != null)
            {
                inventorySlots.Add(slotComponent);
            }
        }
    }
}
