using UnityEngine;
using UnityEngine.UI;
public class SlotsInv : MonoBehaviour
{
    public InventoryItem currentItem;
    public Image itemIcon;

    public bool IsEmpty() => currentItem == null;

    public void AddItem(InventoryItem newItem)
    {
        currentItem = newItem;
        itemIcon.sprite = newItem.icon;
        itemIcon.enabled = true;
    }
}