using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class condicionVictoria : MonoBehaviour
{
    public CaracteristicasArma contador;
    public GameObject pantallaVictoria;
    
    void Start()
    {
        contador = GetComponent<CaracteristicasArma>();
    }

    
    void Update()
    {
        //pantallaDerrota.SetActive(true);
        if (contador.contadorAsesinatos >= 5)
        {
            Time.timeScale = 0;
            pantallaVictoria.SetActive(true);
        }
    }
}