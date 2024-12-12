using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;
using UnityEngine.UI;
public class crecimientoCultivos : MonoBehaviour
{
    //Variables para 
    private float tiempoControlCrecer = 0f;
    public float tiempoCrecer;
    public GameObject cultivoCrecido;
    private int contadorCultivo;
    public GameObject imgCrecido;
    public Image imagenContador;
    public GameObject imagencontador;

    void Start()
    {
        imgCrecido.SetActive(false);
        cultivoCrecido.SetActive(false);
        contadorCultivo = 0;
        imagenContador.fillAmount = 1f;
    }

    void Update()
    {
        imagencontador.SetActive(true);
        tiempoControlCrecer += Time.deltaTime;
        imagenContador.fillAmount = 1 - (tiempoControlCrecer / tiempoCrecer);
        if (tiempoControlCrecer >= tiempoCrecer)
        {
            CrecimientoCultivo();
        }
    }
    private void CrecimientoCultivo()
    {
        tiempoControlCrecer = 0f;
        Debug.Log("CRECIO EL CULTIVO");
        cultivoCrecido.SetActive(true);
        imagencontador.SetActive(false);
        imgCrecido.SetActive(true);
        gameObject.SetActive(false);
    }
}
