using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    public Transform puntorespawn;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = puntorespawn.position;
        }
    }
}
