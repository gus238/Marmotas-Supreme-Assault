using System.Collections;
using UnityEngine;
using TMPro;

public class M4 : MonoBehaviour
{
    [Header("Propiedades del Arma")]
    public int daño = 20;
    public float fireRate = 0.1f;
    public float rango = 50f;
    public float tiempoRecarga = 2.5f;
    public float tiempoEntreRafaga = 0.1f;
    public int tamañoCargador = 30;
    public int tamañoRafaga = 3;
    public bool mantenerApretado = true;

    [Header("Estado de Munición")]
    private int balasRestantes;
    private int balasDisparadas;

    [Header("Control de Disparo")]
    private bool disparando;
    private bool listoParaDisparar = true;
    private bool recargando;

    [Header("Referencias")]
    public Camera fpsCam;
    public Transform puntoSalida;
    public LayerMask tagEnemigo;
    public AudioSource audioSource;
    public AudioClip disparoSonido;
    public AudioClip recargaSonido;
    public TextMeshProUGUI text;

    private void Start()
    {
        balasRestantes = tamañoCargador;
    }

    private void Update()
    {
        MiInput();
        text.SetText(balasRestantes + " / " + tamañoCargador);
    }

    private void MiInput()
    {
        disparando = mantenerApretado ? Input.GetKey(KeyCode.Mouse0) : Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && balasRestantes < tamañoCargador && !recargando)
        {
            Recargar();
        }

        if (listoParaDisparar && disparando && !recargando && balasRestantes > 0)
        {
            balasDisparadas = tamañoRafaga;
            Disparar();
        }
    }

    private void Disparar()
    {
        listoParaDisparar = false;
        audioSource.PlayOneShot(disparoSonido);

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit rayHit, rango, tagEnemigo))
        {
            VidaEnemigo vidaEnemigo = rayHit.collider.GetComponent<VidaEnemigo>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.TakeDamage(daño);
            }
        }

        balasRestantes--;
        balasDisparadas--;

        Invoke(nameof(ResetDisparo), fireRate);

        if (balasDisparadas > 0 && balasRestantes > 0)
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
        audioSource.PlayOneShot(recargaSonido);
        Invoke(nameof(RecargaTerminada), tiempoRecarga);
    }

    private void RecargaTerminada()
    {
        balasRestantes = tamañoCargador;
        recargando = false;
    }
}

