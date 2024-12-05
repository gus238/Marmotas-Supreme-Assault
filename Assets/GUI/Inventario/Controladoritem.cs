using UnityEngine;

public class ControladorItem : MonoBehaviour
{
    public InventoryItem item;
    private InventoryManager inventoryManager;

    private void Start()
    {
        // Busca el InventoryManager en la escena
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Comprueba si es el jugador
        {
            Recoger();
        }
    }

    public void Recoger()
    {
        Debug.Log($"Recogiste el ítem: {item.itemName}");
        if (inventoryManager != null)
        {
            inventoryManager.AddItemToInventory(item); // Accede a la instancia encontrada
        }
        Destroy(gameObject); // Elimina el objeto del mundo
    }
}
