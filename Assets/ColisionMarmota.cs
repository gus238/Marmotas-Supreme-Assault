
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionMarmota : MonoBehaviour
{
    public LayerMask Marmota;
    public float tiempo = 5.0f;
    private float tiempoMuerte = 0f; 

    void OnCollisionStay(Collision collision)
    {
        if ((Marmota.value & (1 << collision.gameObject.layer)) != 0)
        {
          tiempoMuerte += Time.deltaTime;
          if (tiempoMuerte >= tiempo)
            {
              Debug.Log("PERDISTE");
              tiempoMuerte = 0f; 
            }
        }
        else
        {
          tiempoMuerte = 0f;
        }
    }
}


