// File name: CaracteristicasArma.cs

using TMPro;
using UnityEngine;

public class CaracteristicasArma : MonoBehaviour
{
    [Header("Arma Actual")]
    public InventoryItem armaActual;
    private GameObject armaInstanciada;

    [Header("Referencias")]
    public Camera fpsCam;
    public AudioSource audioSource;
    public TextMeshProUGUI text;
    public Transform puntoSalida;
    public Transform posicionArmaJugador;

    private bool listoParaDisparar = true;
    private bool recargando = false;

    void Start()
    {
        if (armaActual != null)
        {
            armaActual.balasRestantes = armaActual.tamañoCargador;
            text.SetText(armaActual.balasRestantes + " / " + armaActual.tamañoCargador);
            InstanciarModeloArma();
        }
    }

    void Update()
    {
        MiInput();
        if (armaActual != null)
        {
            text.SetText(armaActual.balasRestantes + " / " + armaActual.tamañoCargador);
        }
    }

    private void MiInput()
    {
        if (armaActual != null)
        {
            bool disparando = armaActual.mantenerApretado ? Input.GetKey(KeyCode.Mouse0) : Input.GetKeyDown(KeyCode.Mouse0);
            if (Input.GetKeyDown(KeyCode.R) && armaActual.balasRestantes < armaActual.tamañoCargador && !recargando)
            {
                Recargar();
            }

            if (listoParaDisparar && disparando && !recargando && armaActual.balasRestantes > 0)
            {
                Disparar();
            }
        }
    }

    private void Disparar()
    {
        listoParaDisparar = false;
        armaActual.Disparar(fpsCam, audioSource);
        Invoke(nameof(ResetDisparo), armaActual.fireRate);
    }

    private void ResetDisparo()
    {
        listoParaDisparar = true;
    }

    private void Recargar()
    {
        recargando = true;
        armaActual.Recargar(audioSource);
        Invoke(nameof(RecargaTerminada), armaActual.tiempoRecarga);
    }

    private void RecargaTerminada()
    {
        recargando = false;
    }

    private void InstanciarModeloArma()
    {
        if (armaActual.modeloArma != null && posicionArmaJugador != null)
        {
            armaInstanciada = Instantiate(armaActual.modeloArma, posicionArmaJugador.position, posicionArmaJugador.rotation, posicionArmaJugador);
        }
    }
}
