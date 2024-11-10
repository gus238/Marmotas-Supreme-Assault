using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class economiaJugador : MonoBehaviour
{
    public int cantidadMonedas;
    public TextMeshProUGUI cantMonedas;
    public float tiempoJuego = 0f;
    

    void Start()
    {
        cantidadMonedas = 0;   
    }
    
    void Update()
    {
        tiempoJuego += Time.deltaTime;
        if (tiempoJuego >= 1f)
        {
            cantidadMonedas += 1;
            tiempoJuego = 0f;
        }
        cantMonedas.SetText(cantidadMonedas.ToString());
    }

    public void RecibirMonedas(int cantidadRecibida)
    {
        cantidadMonedas += cantidadRecibida;
        Debug.Log(cantidadMonedas);
    }

}
