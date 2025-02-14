using UnityEngine;

public class RecogerArma : MonoBehaviour
{
    public Transform ManoJugador; // Lugar donde se equipará el arma

    private bool enRango = false;
    private Rigidbody rb; // Referencia al Rigidbody del arma

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener Rigidbody del arma
    }

    void Update()
    {
        if (enRango && Input.GetKeyDown(KeyCode.E))
        {
            Recoger();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enRango = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enRango = false;
        }
    }

    private void Recoger()
    {
        // Desactivar físicas del arma
        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        // Equipar en la mano del jugador
        transform.SetParent(ManoJugador);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
