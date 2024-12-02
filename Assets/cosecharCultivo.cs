using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CosecharCultivo : MonoBehaviour
{
    public GameObject[] cultivosListosParaCosechar;
    public GameObject canvaCosecha;
    public GameObject barraCosecha;
    public Slider sliderCosecha;
    public GameObject player;

    public float tiempoBasePresionE = 3.0f; 
    private float tiempoCosecha;
    private bool triggerStayBool;

    void Start()
    {
        barraCosecha.SetActive(false);
        triggerStayBool = false;
        canvaCosecha.SetActive(false);
        sliderCosecha.value = 1f;
    }

    void Update()
    {
        int cultivosActivos = ContarCultivosActivos();

        if (triggerStayBool && cultivosActivos > 0 && Input.GetKey(KeyCode.E))
        {
            var script = player.GetComponent<MovimientoJugador>();
            barraCosecha.SetActive(true);
            float tiempoRequerido = tiempoBasePresionE * cultivosActivos;
            tiempoCosecha += Time.deltaTime;
            sliderCosecha.value = 1f - (tiempoCosecha / tiempoRequerido);
            script.enabled = false;

            if (tiempoCosecha >= tiempoRequerido)
            {
                CosecharCultivos();
                ResetearTiempoCosecha();
            }
        }
        else
        {
            var script = player.GetComponent<MovimientoJugador>();
            script.enabled = true;
            barraCosecha.SetActive(false);
            ResetearTiempoCosecha();
        }
    }

    private int ContarCultivosActivos()
    {
        int activos = 0;
        foreach (var cultivo in cultivosListosParaCosechar)
        {
            if (cultivo.activeSelf)
                activos++;
        }
        return activos;
    }

    private void CosecharCultivos()
    {
        foreach (var cultivo in cultivosListosParaCosechar)
        {
            if (cultivo.activeSelf)
            {
                var cultivoScript = cultivo.GetComponent<RecogerCultivo>();
                cultivoScript.DarDinero();
                cultivo.SetActive(false);
            }
        }
    }

    void OnTriggerStay(Collider objeto)
    {
        if (objeto.tag == ("Player"))
        {
            int cultivosActivos = ContarCultivosActivos();
            canvaCosecha.SetActive(cultivosActivos > 0);
            triggerStayBool = true;
        }
    }

    void OnTriggerExit(Collider objeto)
    {
        if (objeto.tag == ("Player"))
        {
            barraCosecha.SetActive(false);
            canvaCosecha.SetActive(false);
            triggerStayBool = false;
        }
    }

    public void ResetearTiempoCosecha()
    {
        tiempoCosecha = 0f;
        sliderCosecha.value = 1f;
    }
}

/*
public class DeshabilitarOtroScript : MonoBehaviour
{
    public GameObject otroGameObject; // Referencia al GameObject que tiene el script
    public string nombreScript;       // Nombre del script que quieres deshabilitar

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Obtener el script del otro GameObject
            var script = otroGameObject.GetComponent(nombreScript) as MonoBehaviour;

            if (script != null)
            {
                script.enabled = false; // Desactivar el script
                Debug.Log($"El script {nombreScript} en {otroGameObject.name} ha sido desactivado.");
            }
            else
            {
                Debug.LogWarning($"No se encontró el script {nombreScript} en {otroGameObject.name}.");
            }
        }
    }
}*/
