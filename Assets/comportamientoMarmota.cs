using UnityEngine;
using UnityEngine.AI;

public class MarmotaAtaque : MonoBehaviour
{
    [Header("Propiedades de la marmota")]
    public float rangoAtaque = 2f; // Distancia a la que puede atacar
    public float daño = 10f; // Daño que inflige por ataque
    public float tiempoEntreAtaques = 1.5f; // Tiempo entre ataques
    private bool yaAtacando = false;

    [Header("Referencias de Objetivos")]
    public Transform granjero; // Referencia al granjero (jugador)
    public Transform granja; // Referencia a la granja

    [Header("Atributos de Navegación")]
    private NavMeshAgent agente;
    private Transform objetivoActual;

    [Header("Rango de Prioridad")]
    public float rangoPrioridadGranjero = 10f; // Rango en el que la marmota prioriza al granjero sobre la granja

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();

        // Al inicio, la marmota se dirigirá hacia la granja por defecto
        objetivoActual = granja;
    }

    void Update()
    {
        // Cambiar de objetivo si el granjero está dentro del rango de prioridad
        float distanciaAlGranjero = Vector3.Distance(transform.position, granjero.position);
        if (distanciaAlGranjero <= rangoPrioridadGranjero)
        {
            objetivoActual = granjero; // Prioriza atacar al granjero si está cerca
        }
        else
        {
            objetivoActual = granja; // Si no, va hacia la granja
        }

        // Mover la marmota hacia el objetivo actual
        agente.SetDestination(objetivoActual.position);

        // Comprobar si está dentro del rango de ataque para atacar
        float distanciaAlObjetivo = Vector3.Distance(transform.position, objetivoActual.position);
        if (distanciaAlObjetivo <= rangoAtaque && !yaAtacando)
        {
            // Iniciar ataque
            yaAtacando = true;
            Ataque();
        }
    }

    private void Ataque()
    {
        // Atacar al objetivo actual (granjero o granja)
        if (objetivoActual == granjero)
        {
            Debug.Log("Marmota ataca al granjero!");
            // Aquí puedes reducir la vida del granjero
            // granjero.GetComponent<VidaGranjero>().TomarDaño(daño);
        }
        else if (objetivoActual == granja)
        {
            Debug.Log("Marmota ataca a la granja!");
            // Aquí puedes reducir la salud de la granja
            // granja.GetComponent<VidaGranja>().TomarDaño(daño);
        }

        // Reiniciar el ataque después de un tiempo
        Invoke(nameof(ResetAtaque), tiempoEntreAtaques);
    }

    private void ResetAtaque()
    {
        yaAtacando = false;
    }
}