using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionCamara : MonoBehaviour
{
    public Transform posicionCamara;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position = posicionCamara.position;
    }
}
