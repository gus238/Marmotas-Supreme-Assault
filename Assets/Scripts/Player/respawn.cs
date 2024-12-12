using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public Transform puntorespawn;
    
    
    void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = puntorespawn.position; //si el jugador cae del mapa, aparecerá donde se encuentra el Empty dentro del juego, es decir, hara un spawn
        }
    }
}
