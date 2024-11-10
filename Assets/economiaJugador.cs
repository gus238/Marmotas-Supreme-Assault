using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class economiaJugador : MonoBehaviour
{
    public int cantidadMonedas;
    public TextMeshProUGUI cantMonedas;

    void Start()
    {
        cantidadMonedas = 0;
    }

    void Update()
    {
        cantMonedas.SetText(cantidadMonedas.ToString());
    }

    public void RecibirMonedas(int cantidadRecibida)
    {
        cantidadMonedas += cantidadRecibida;
        Debug.Log(cantidadMonedas);
    }

}
