using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Slider barraDeVida;
    public float vidaMaxima = 100f;
    public float vidaActual;
    public GameObject pantallaDerrota;

    void OnTriggerStay(Collider other)
    {
        GameObject objeto = other.gameObject;
        if ((objeto.tag == "Enemy") && (Time.timeScale == 1))
        {
            EnemyAIMovement enemigo = objeto.GetComponent<EnemyAIMovement>();
            if (enemigo != null)
            {
                ReducirVida(enemigo.Damage);
            }
        }
        else
        {

        }
    }
    void Start()
    {
        vidaActual = vidaMaxima;
        barraDeVida.maxValue = vidaMaxima;
        barraDeVida.value = vidaActual;
    }

    void Update()
    {
        if (vidaActual <= 0)
        {
            Time.timeScale = 0;
            pantallaDerrota.SetActive(true);
        }
    }

    public void ReducirVida(float cantidad) 
    {
        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        barraDeVida.value = vidaActual;
    }
}
