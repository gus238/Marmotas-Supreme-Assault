using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Slider barraDeVida;
    public Slider barraDeVidaAmarilla;
    public float vidaMaxima = 100f;
    public float vidaActual;
    public GameObject pantallaDerrota;
    private Coroutine damageCoroutine;
    private float velBarraAmarilla = 0.05f;

    void OnTriggerStay(Collider other)
    {
       
        GameObject objeto = other.gameObject;
        if ((objeto.tag == "Enemy") && (Time.timeScale == 1))
        {
            EnemyAIMovement enemigo = objeto.GetComponent<EnemyAIMovement>();
            if (enemigo != null && damageCoroutine == null)
            {
                // Empieza a hacer daño a intervalos de tiempo
                damageCoroutine = StartCoroutine(ReducirVidaConIntervalo(enemigo));
               
            }
        }
        else
        {

        }
    }
    void OnTriggerExit(Collider other)
    {
        // Detiene el daño cuando el enemigo sale del área
        if (other.CompareTag("Enemy") && damageCoroutine != null)
        {
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }

    private IEnumerator ReducirVidaConIntervalo(EnemyAIMovement enemigo)
    {
        while (true)
        {
            ReducirVida(enemigo.Damage); // Aplica el daño del enemigo
            yield return new WaitForSeconds(enemigo.attackCooldown); // Espera el tiempo de cooldown
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
        if (barraDeVida.value != barraDeVidaAmarilla.value)
        {
            barraDeVidaAmarilla.value = Mathf.Lerp(barraDeVidaAmarilla.value, vidaActual, velBarraAmarilla);
        }
    }

    public void ReducirVida(float cantidad) 
    {
        vidaActual -= cantidad;
        vidaActual = Mathf.Clamp(vidaActual, 0, vidaMaxima);

        barraDeVida.value = vidaActual;
    }
}
