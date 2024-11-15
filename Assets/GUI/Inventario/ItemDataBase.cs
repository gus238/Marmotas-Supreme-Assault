// File name: ItemDatabase.cs

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDatabase", menuName = "Inventory/ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    public List<InventoryItem> items;

    public InventoryItem GetItemByName(string itemName)
    {
        return items.Find(item => item.itemName == itemName);
    }
}
