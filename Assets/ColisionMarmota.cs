using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionMarmota : MonoBehaviour
{
    public float tiempo = 3.0f;
    private float tiempoMuerte = 0f;
    public GameObject pantallaDerrota;

    void OnTriggerStay(Collider other)
    {
        GameObject objeto = other.gameObject;
        if ((objeto.tag == "Enemy") && (Time.timeScale == 1))
        {
          tiempoMuerte += Time.deltaTime;
          if (tiempoMuerte >= tiempo)
            {
              Time.timeScale = 0;
              tiempoMuerte = 0f;
              pantallaDerrota.SetActive(true);
            }
        }
        else
        {
          tiempoMuerte = 0f;
        }
    }
}


