using UnityEngine;

public class FirstPersonControllerWithArms : MonoBehaviour
{
    public Transform arms;          // Los brazos con el arma
    public float mouseSensitivity = 100f;  // Sensibilidad del mouse
    public float moveSpeed = 5f;    // Velocidad de movimiento
    public Vector3 armsOffset = new Vector3(0.2f, -0.5f, 0.5f);  // Offset ajustable desde el Inspector para los brazos

    private float xRotation = 0f;   // Control de la rotación en el eje X (vertical)
    private CharacterController controller;
    private Camera playerCamera;    // Referencia a la cámara en el mismo objeto

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;  // Bloquear el cursor al centro de la pantalla
        controller = GetComponent<CharacterController>();

        // Obtener la cámara en el mismo objeto donde está el script
        playerCamera = GetComponentInChildren<Camera>();

        if (playerCamera == null)
        {
            Debug.LogError("No se encontró ninguna cámara en este objeto o en sus hijos.");
            return;
        }

        // Forzar la posición inicial de los brazos
        UpdateArmsPosition();
    }

    void Update()
    {
        RotateView();   // Maneja la rotación de la cámara
        MovePlayer();   // Maneja el movimiento del jugador
        UpdateArmsPosition(); // Asegura que los brazos sigan a la cámara
    }

    // Método para rotar la cámara
    void RotateView()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Limitar la rotación vertical

        // Rotar la cámara en el eje X para la vista vertical
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotar el cuerpo del personaje en el eje Y para la vista horizontal
        transform.Rotate(Vector3.up * mouseX);
    }

    // Método para mover al jugador
    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move);  // Mover al jugador usando el CharacterController
    }

    // Método para alinear los brazos con la cámara
    void UpdateArmsPosition()
    {
        // Ajustar la posición de los brazos en relación con la cámara
        arms.position = playerCamera.transform.position + playerCamera.transform.forward * armsOffset.z + playerCamera.transform.right * armsOffset.x + Vector3.up * armsOffset.y;

        // Aplicar rotación adicional de 180 grados en el eje Y para que los brazos no estén al revés
        Quaternion cameraRotation = playerCamera.transform.rotation * Quaternion.Euler(0f, 180f, 0f);
        arms.rotation = cameraRotation;
    }
}