using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarArmas : MonoBehaviour
{
    public GameObject[] armas;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivarArma(int numero)
    {
        for (int i = 0; i < armas.Length; i++)
        {
            armas[i].SetActive(false);
        }

        armas[numero].SetActive(true);
    }






}
