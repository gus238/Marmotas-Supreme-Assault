using UnityEngine;

public class MarmotaAnimacion : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Obtener el componente Animator del GameObject
        animator = GetComponent<Animator>();

        // Verificar si el Animator está presente
        if (animator == null)
        {
            Debug.LogError("El componente Animator no está asignado en el GameObject.");
            return;
        }

        // Reproducir la animación "PIPO" en bucle desde el principio
        // Asegurándose de que la animación se repita siempre
        animator.Play("PIPO", 0, 0f);
    }

    void Update()
    {
        // Verificar si la animación "PIPO" está corriendo, y reiniciarla si es necesario
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("PIPO"))
        {
            animator.Play("PIPO", 0, 0f);  // Reiniciar la animación para que nunca se detenga
        }
    }
}
