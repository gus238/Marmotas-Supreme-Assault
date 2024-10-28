using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaracteristicasArma : MonoBehaviour
{
    [Header("Propiedades del Arma")]
    public int daño;
    public float fireRate;
    public float rango;
    public float tiempoRecarga;
    public float tiempoEntreRafaga;
    public int tamañoCargador;
    public int tamañoRafaga;
    public bool mantenerApretado;

    [Header("Estado de Munición")]
    int balasRestantes;
    int balasDisparadas;

    [Header("Control de Disparo")]
    bool disparando;
    bool listoParaDisparar;
    bool recargando;

    [Header("Referencias")]
    public Camera fpsCam;
    public Transform puntoSalida;
    public RaycastHit rayHit;
    public LayerMask tagEnemigo;
    public TextMeshProUGUI text;

    private void MiInput()
    {
        if (mantenerApretado)
        {
            disparando = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            disparando = Input.GetKeyDown(KeyCode.Mouse0); 
        }
        if (Input.GetKeyDown(KeyCode.R) && balasRestantes < tamañoCargador && !recargando && (Time.timeScale == 1))
        {
            Recargar();
        }

        if (listoParaDisparar && disparando && !recargando && balasRestantes > 0 && (Time.timeScale == 1))
        {
            balasDisparadas = tamañoRafaga;
            Disparar();
        }
    }
    private void Disparar()
    {
        listoParaDisparar = false;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out rayHit, rango, tagEnemigo) && (Time.timeScale == 1))
        {
            Debug.Log(rayHit.collider.name);

            //if (rayHit.collider.CompareTag("Enemy"))
            //{
            rayHit.collider.gameObject.SetActive(false);
                //rayHit.collider.getComponent<ShootingAI>().TakeDamage(damage);
            //}
        }

        balasRestantes--;
        balasDisparadas--;

        Invoke(nameof(ResetDisparo), fireRate);

        if (balasDisparadas > 0 && balasRestantes > 0 && (Time.timeScale == 1))
        {
            Invoke(nameof(Disparar), tiempoEntreRafaga);
        }
    }
    private void ResetDisparo()
    {
        listoParaDisparar = true;
    }
    private void Recargar()
    {
        recargando = true;
        Invoke("RecargaTerminada", tiempoRecarga);
    }

    private void RecargaTerminada()
    {
        balasRestantes = tamañoCargador;
        recargando = false;
    }
    void Start()
    {
        balasRestantes = tamañoCargador;
        listoParaDisparar = true;
    }

    
    void Update()
    {
        MiInput();

        text.SetText(balasRestantes + " / " + tamañoCargador);
    }
}
