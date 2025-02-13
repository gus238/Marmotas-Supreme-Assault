using UnityEngine;
using System.Collections.Generic;

public class WeaponInventory : MonoBehaviour
{
    public List<Weapon> weapons = new List<Weapon>();  // Lista de armas del inventario
    public GameObject currentWeapon;  // El arma actualmente equipada
    private int currentWeaponIndex = -1;  // �ndice del arma equipada

    // M�todo para agregar un arma al inventario
    public void AgregarArma(Weapon newWeapon)
    {
        // Si el inventario tiene espacio (por ejemplo, m�ximo 4 armas)
        if (weapons.Count < 4)
        {
            weapons.Add(newWeapon);  // A�adir el arma al inventario
            Debug.Log("Arma agregada al inventario: " + newWeapon.weaponName);
        }
        else
        {
            Debug.Log("Inventario lleno. No puedes agregar m�s armas.");
        }
    }

    // M�todo para cambiar de arma
    public void CambiarArma(int index)
    {
        if (index >= 0 && index < weapons.Count)
        {
            if (currentWeapon != null)
            {
                currentWeapon.SetActive(false);  // Desactiva el arma actual
            }

            currentWeapon = weapons[index].weaponObject;  // Establece el arma seleccionada
            currentWeapon.SetActive(true);  // Activa el arma seleccionada
            currentWeaponIndex = index;  // Actualiza el �ndice del arma seleccionada

            Debug.Log("Arma cambiada a: " + weapons[index].weaponName);
        }
    }

    // M�todo para quitar el arma actual
    public void QuitarArma()
    {
        if (currentWeapon != null)
        {
            currentWeapon.SetActive(false);  // Desactiva el arma
            weapons.RemoveAt(currentWeaponIndex);  // Elimina el arma del inventario
            currentWeapon = null;  // Restablece la referencia al arma actual
            currentWeaponIndex = -1;  // Restablece el �ndice
            Debug.Log("Arma quitada del inventario.");
        }
    }

    // M�todo que se llama en cada frame
    void Update()
    {
        // Si el jugador presiona 1, 2, 3 o 4, se cambia de arma
        if (Input.GetKeyDown(KeyCode.Alpha1)) CambiarArma(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) CambiarArma(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3)) CambiarArma(2);
        else if (Input.GetKeyDown(KeyCode.Alpha4)) CambiarArma(3);
    }
}
