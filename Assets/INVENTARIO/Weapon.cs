using UnityEngine;

public class Weapon
{
    public string weaponName;        // Nombre del arma
    public GameObject weaponObject;  // GameObject del arma

    // Constructor de Weapon que toma un GameObject (el arma en el mundo)
    public Weapon(GameObject weaponObject)
    {
        this.weaponObject = weaponObject;  // Asigna el GameObject del arma
        this.weaponName = weaponObject.name; // Asigna el nombre del GameObject como el nombre del arma
    }

    // Método para equipar el arma
    public void Equipar()
    {
        weaponObject.SetActive(true);  // Activa el GameObject del arma
    }

    // Método para desequipar el arma
    public void Desequipar()
    {
        weaponObject.SetActive(false);  // Desactiva el GameObject del arma
    }
}

