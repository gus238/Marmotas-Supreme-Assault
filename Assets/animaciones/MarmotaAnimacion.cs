using UnityEngine;

public class MarmotaAnimacion : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Obtener el componente Animator del GameObject
        animator = GetComponent<Animator>();

        // Verificar si el Animator est� presente
        if (animator == null)
        {
            Debug.LogError("El componente Animator no est� asignado en el GameObject.");
            return;
        }

        // Reproducir la animaci�n "PIPO" en bucle desde el principio
        // Asegur�ndose de que la animaci�n se repita siempre
        animator.Play("PIPO", 0, 0f);
    }

    void Update()
    {
        // Verificar si la animaci�n "PIPO" est� corriendo, y reiniciarla si es necesario
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("PIPO"))
        {
            animator.Play("PIPO", 0, 0f);  // Reiniciar la animaci�n para que nunca se detenga
        }
    }
}
