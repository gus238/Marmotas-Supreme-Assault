using UnityEngine;
using TMPro;

public class CaracteristicasArma : MonoBehaviour
{
    [Header("Arma Actual")]
    public InventoryItem armaActual;  // Asegúrate de que esto sea público
    private GameObject armaInstanciada;

    [Header("Referencias")]
    public Camera fpsCam;            // Asegúrate de que esto sea público
    public AudioSource audioSource;  // Asegúrate de que esto sea público
    public TextMeshProUGUI text;     // Asegúrate de que esto sea público
    public Transform puntoSalida;
    public Transform posicionArmaJugador;

    public bool listoParaDisparar = true;  // Asegúrate de que esto sea público
    public bool recargando = false;        // Asegúrate de que esto sea público

    void Start()
    {
        if (armaActual != null)
        {
            // Inicializa las propiedades del arma, como las balas y los sonidos
            armaActual.balasRestantes = armaActual.tamañoCargador;
            text.SetText(armaActual.balasRestantes + " / " + armaActual.tamañoCargador);
            InstanciarModeloArma();
        }
    }

    void Update()
    {
        ProcesarEntrada();
        if (armaActual != null)
        {
            text.SetText(armaActual.balasRestantes + " / " + armaActual.tamañoCargador);
        }
    }

    private void InstanciarModeloArma()
    {
        if (armaActual.modeloArma != null && posicionArmaJugador != null)
        {
            armaInstanciada = Instantiate(armaActual.modeloArma, posicionArmaJugador.position, posicionArmaJugador.rotation, posicionArmaJugador);
        }
    }

    // Cambié el nombre de MiInput a ProcesarEntrada
    private void ProcesarEntrada()
    {
        if (armaActual != null)
        {
            bool disparando = armaActual.mantenerApretado ? Input.GetKey(KeyCode.Mouse0) : Input.GetKeyDown(KeyCode.Mouse0);
            if (Input.GetKeyDown(KeyCode.R) && armaActual.balasRestantes < armaActual.tamañoCargador && !recargando && (Time.timeScale == 1))
            {
                Recargar();
            }

            if (listoParaDisparar && disparando && !recargando && armaActual.balasRestantes > 0 && (Time.timeScale == 1))
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
}
