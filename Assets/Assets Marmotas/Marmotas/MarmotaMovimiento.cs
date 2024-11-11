using UnityEngine;
using UnityEngine.AI;

public class MarmotaMovimiento : MonoBehaviour
{
    public Transform objetivo; // Arrastra el jugador aquí en el inspector
    private Animator anim;
    private NavMeshAgent agente;

    void Start()
    {
        anim = GetComponent<Animator>();
        agente = GetComponent<NavMeshAgent>();
        agente.speed = 2.0f; // Configura la velocidad de la marmota
    }

    void Update()
    {
        agente.SetDestination(objetivo.position);

        if (agente.velocity.magnitude > 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
