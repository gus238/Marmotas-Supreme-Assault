using System.Collections;
using UnityEngine;
using TMPro;

public class Benelli : MonoBehaviour
{
    [Header("Propiedades del Arma")]
    public int daño = 50;
    public float fireRate = 1f;
    public float rango = 25f;
    public float tiempoRecarga = 3f;
    public int tamañoCargador = 8;
    public bool mantenerApretado = false;

    [Header("Estado de Munición")]
    private int balasRestantes;

    [Header("Control de Disparo")]
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
        if (Input.GetKeyDown(KeyCode.Mouse0) && listoParaDisparar && !recargando && balasRestantes > 0)
        {
            Disparar();
        }

        if (Input.GetKeyDown(KeyCode.R) && balasRestantes < tamañoCargador && !recargando)
        {
            Recargar();
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

        Invoke(nameof(ResetDisparo), fireRate);
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
