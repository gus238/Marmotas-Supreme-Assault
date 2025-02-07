using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public InventoryItem weaponItem;

    private void OnTriggerEnter(Collider other)
    {
        InventoryManager inventory = other.GetComponent<InventoryManager>();
        if (inventory != null && inventory.AddItemToInventory(weaponItem))
        {
            Destroy(gameObject);
        }
    }
}

