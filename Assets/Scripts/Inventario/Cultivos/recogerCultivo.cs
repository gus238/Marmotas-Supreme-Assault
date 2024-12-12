using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerCultivo : MonoBehaviour
{
    //Variables que toma la parcela en la que esta plantado, el jugador y cuanto dinero da
    public int valorCultivo;
    public GameObject player;
    public GameObject parcela;
    public GameObject imagenCrecido;

    //Toma el dinero que tiene el jugador
    economiaJugador dinero;

    void Start()
    {
        dinero = player.GetComponent<economiaJugador>();
    }

    //Desactiva la imagen de cultivo listo para cosechar y le da al jugador el dinero igual al valor que se le asigna en el editor
    public void DarDinero()
    {
        Debug.Log("Cultivo cosechado, añadiendo dinero.");
        dinero.cantidadMonedas += valorCultivo;
        imagenCrecido.SetActive(false);
    }
}

