using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<SlotsInv> inventorySlots = new List<SlotsInv>();
    public Transform inventoryPanel;
    public ItemDatabase itemDatabase; // Reference to the item database
    private bool isInventoryOpen = false;

    private void Start()
    {
        InitializeInventory();
        inventoryPanel.gameObject.SetActive(isInventoryOpen); // Start inventory closed
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

        // Manage cursor visibility and locking
        Cursor.lockState = isInventoryOpen ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isInventoryOpen;
    }

    private void InitializeInventory()
    {
        // Automatically add all child slots from the GridLayout
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

        // Load items into the slots from the database
        for (int i = 0; i < itemDatabase.items.Count && i < inventorySlots.Count; i++)
        {
            inventorySlots[i].AddItem(itemDatabase.items[i]);
        }
    }

    public void AddItemToInventory(InventoryItem newItem)
    {
        // Add an item to the first empty slot
        foreach (var slot in inventorySlots)
        {
            if (slot.item == null)
            {
                slot.AddItem(newItem);
                return;
            }
        }

        Debug.LogWarning("No empty slots available in inventory!");
    }
}
