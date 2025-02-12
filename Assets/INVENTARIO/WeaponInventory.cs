using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponInventory : MonoBehaviour
{
    [Header("Armas Disponibles")]
    public CaracteristicasArmaOriginal pistola;
    public CaracteristicasArmaOriginal m4;
    public CaracteristicasArmaOriginal benelli;
    public CaracteristicasArmaOriginal granada;

    private CaracteristicasArmaOriginal armaActual;

    void Start()
    {
        EquiparArma(pistola); // Iniciar con la pistola
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            EquiparArma(pistola);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            EquiparArma(m4);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            EquiparArma(benelli);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            EquiparArma(granada);
    }

    void EquiparArma(CaracteristicasArmaOriginal nuevaArma)
    {
        if (armaActual != null)
            armaActual.gameObject.SetActive(false);

        armaActual = nuevaArma;
        if (armaActual != null)
            armaActual.gameObject.SetActive(true);
    }
}
