using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int valorMoneda = 1; // Cantidad de monedas que otorga esta moneda

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga la etiqueta "Player"
        {
            economiaJugador economia = other.GetComponent<economiaJugador>();
            if (economia != null)
            {
                economia.RecibirMonedas(valorMoneda); // Agrega las monedas al jugador
                Destroy(gameObject); // Destruye la moneda después de recogerla
            }
        }
    }
}
