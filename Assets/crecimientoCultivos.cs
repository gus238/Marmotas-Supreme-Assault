using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crecimientoCultivos : MonoBehaviour
{
    private int contadorOleada;
    public GameObject objetoOleadas;
    ZonaDeSpawnManager oleadas;
    private int contadorCultivo;
    public int cantOleadasParaCosechar;

    void Start()
    {
        contadorCultivo = 0;
        oleadas = objetoOleadas.GetComponent<ZonaDeSpawnManager>();
        contadorOleada = oleadas.oleadaActual;
    }

    void Update()
    {
        if (contadorOleada != oleadas.oleadaActual)
        {
            contadorOleada = oleadas.oleadaActual;
            contadorCultivo++;
            CrecimientoCultivo();
        }
    }
    private void CrecimientoCultivo()
    {
        if (contadorCultivo == cantOleadasParaCosechar)
        {
            Debug.Log("Listo para Cosechar");
        }
    }
}
