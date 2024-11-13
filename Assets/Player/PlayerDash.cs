using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 5f;      // Distancia del dash
    public float dashCooldown = 1f;      // Tiempo de espera entre dashes
    public float dashDuration = 0.2f;    // Duraci�n del dash

    private bool canDash = true;         // Verifica si el jugador puede hacer dash
    private Vector3 dashDirection;       // Direcci�n del dash
    private CharacterController controller;
    private float dashTimer;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Verifica si el jugador presiona "Ctrl derecho" y si puede hacer dash
        if (Input.GetKeyDown(KeyCode.RightControl) && canDash)
        {
            dashDirection = transform.forward;
            dashTimer = dashDuration;
            canDash = false;
        }

        // Si est� en medio de un dash, mueve al jugador en la direcci�n
        if (dashTimer > 0)
        {
            controller.Move(dashDirection * (dashDistance / dashDuration) * Time.deltaTime);
            dashTimer -= Time.deltaTime;
        }

        // Reestablece el cooldown para el pr�ximo dash
        if (!canDash && dashTimer <= 0)
        {
            Invoke(nameof(ResetDash), dashCooldown);
        }
    }

    void ResetDash()
    {
        canDash = true;
    }
}
