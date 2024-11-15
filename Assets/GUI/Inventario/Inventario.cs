using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<SlotsInv> inventorySlots;
    public Transform inventoryPanel;
    public ItemDatabase itemDatabase; // Reference to the item database
    private bool isInventoryOpen = false;

    private void Start()
    {
        InitializeInventory();
        inventoryPanel.gameObject.SetActive(isInventoryOpen); // Initialize the inventory as closed
        LoadItemsFromDatabase(); // Load items from the database into the inventory
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

    private void LoadItemsFromDatabase()
    {
        if (itemDatabase == null || itemDatabase.items == null || itemDatabase.items.Count == 0)
        {
            Debug.LogWarning("Item Database is empty or not assigned.");
            return;
        }

        // Load items from the item database into the inventory slots
        for (int i = 0; i < itemDatabase.items.Count && i < inventorySlots.Count; i++)
        {
            inventorySlots[i].AddItem(itemDatabase.items[i]); // Cambiado a InventoryItem
        }
    }
}
