using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionCamara : MonoBehaviour
{
    public Transform posicionCamara;

    
    void Update()
    {
        transform.position = posicionCamara.position; //la posicion se ajusta para que siempre siga al objeto camara
    }
}
