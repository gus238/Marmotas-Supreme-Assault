using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;
public class crecimientoCultivos : MonoBehaviour
{
    private float tiempoControlCrecer = 0f;
    public float tiempoCrecer;
    public GameObject cultivoCrecido;
    private int contadorCultivo;
    public TextMeshProUGUI tiempoHUD;
    public GameObject objetoTexto;
    public GameObject imgCrecido;

    void Start()
    {
        imgCrecido.SetActive(false);
        objetoTexto.SetActive(false);
        cultivoCrecido.SetActive(false);
        contadorCultivo = 0;
    }

    void Update()
    {
        
        tiempoControlCrecer += Time.deltaTime;
        if (tiempoControlCrecer >= tiempoCrecer)
        {
            tiempoControlCrecer = 0f;
            CrecimientoCultivo();
        }
        if (!cultivoCrecido.activeSelf)
        {
            objetoTexto.SetActive(true);
            tiempoHUD.text = tiempoControlCrecer.ToString("F1") + "s";
        }
        /*if (cultivoCrecido.SetActive(true))
        {
            objetoTexto.SetActive(false);
            gameObject.SetActive(false);
        }*/
    }
    private void CrecimientoCultivo()
    {
        Debug.Log("CRECIO EL CULTIVO");
        cultivoCrecido.SetActive(true);
        objetoTexto.SetActive(false);
        imgCrecido.SetActive(true);
        gameObject.SetActive(false);
    }
}
