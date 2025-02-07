using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Inventory Manager - Maneja la UI y el sistema de inventario
public class InventoryManager : MonoBehaviour
{
    public List<SlotsInv> inventorySlots = new List<SlotsInv>();
    public Transform inventoryPanel;
    public Transform weaponHolder;
    public GameObject inventoryUI;
    private bool isInventoryOpen = false;
    private InventoryItem equippedWeapon;

    private void Start()
    {
        InitializeInventory();
        inventoryUI.SetActive(false);
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
        inventoryUI.SetActive(isInventoryOpen);
    }

    private void InitializeInventory()
    {
        inventorySlots.Clear();
        foreach (Transform slotTransform in inventoryPanel)
        {
            SlotsInv slotComponent = slotTransform.GetComponent<SlotsInv>();
            if (slotComponent != null)
            {
                inventorySlots.Add(slotComponent);
            }
        }
    }

    public bool AddItemToInventory(InventoryItem newItem)
    {
        foreach (SlotsInv slot in inventorySlots)
        {
            if (slot.IsEmpty())
            {
                slot.AddItem(newItem);
                return true;
            }
        }
        return false;
    }

    public void EquipWeapon(InventoryItem weapon)
    {
        if (equippedWeapon == weapon)
        {
            return;
        }

        if (weaponHolder.childCount > 0)
        {
            Destroy(weaponHolder.GetChild(0).gameObject);
        }

        equippedWeapon = weapon;
        Instantiate(weapon.modeloArma, weaponHolder);
    }
}

