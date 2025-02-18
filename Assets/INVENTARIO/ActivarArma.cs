using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarArmaPersonaje : MonoBehaviour
{
    public AgarrarArmas AgarrarArmas;
    public int numeroArma;


    void Start()
    {
        AgarrarArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<AgarrarArmas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 

        {
            AgarrarArmas.ActivarArma(numeroArma);
            Destroy(gameObject);
        }
    
    }


}
