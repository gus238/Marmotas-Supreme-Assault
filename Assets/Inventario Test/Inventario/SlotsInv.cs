using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotsInv : MonoBehaviour, IDropHandler
{
    public InventoryItem item; // Cambiado de Item a InventoryItem
    public Image icon;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            ItemDragHandler draggedItem = eventData.pointerDrag.GetComponent<ItemDragHandler>();
            if (draggedItem != null)
            {
                if (item != null)
                {
                    // Swap items if there's already an item in the slot
                    InventoryItem tempItem = item;
                    AddItem(draggedItem.item);
                    draggedItem.currentSlot.AddItem(tempItem);
                }
                else
                {
                    AddItem(draggedItem.item);
                    draggedItem.ClearItem();
                }
            }
        }
    }

    public void AddItem(InventoryItem newItem) // Cambiado para aceptar InventoryItem
    {
        item = newItem;
        icon.sprite = newItem.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
