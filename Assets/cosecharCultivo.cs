/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CosecharCultivo : MonoBehaviour
{
    public GameObject[] cultivosListosParaCosechar;
    public GameObject canvaCosecha;
    public GameObject barraCosecha;
    public Slider sliderCosecha;
    public float tiempoDePresionE = 3.0f;
    public bool ningunCultivoCrecido;
    private float tiempoCosecha;
    private bool triggerStayBool;
    private bool presionBoton;
    int contadorCultivoCrecido;

    void Start()
    {
        barraCosecha.SetActive(false);
        triggerStayBool = false;
        presionBoton = false;
        canvaCosecha.SetActive(false);
        sliderCosecha.value = 1f;
        ningunCultivoCrecido = true;
        contadorCultivoCrecido = 0;
    }

    void Update()
    {
        if (triggerStayBool && Input.GetKey(KeyCode.E) && !ningunCultivoCrecido)
        {
            barraCosecha.SetActive(true);
            tiempoCosecha += Time.deltaTime;
            sliderCosecha.value = 1f - (tiempoCosecha / tiempoDePresionE);

            if (ningunCultivoCrecido)
            {
                barraCosecha.SetActive(false);
            }
            if (tiempoCosecha >= tiempoDePresionE)
            {
                contadorCultivoCrecido = 0;

                CosecharCultivos();
                ResetearTiempoCosecha();
            }
        }
        else
        {
            barraCosecha.SetActive(false);
            ResetearTiempoCosecha();
        }
       
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
        if (objeto.CompareTag("Player"))
        {
            canvaCosecha.SetActive(true);
            triggerStayBool = true;
        }
    }

    void OnTriggerExit(Collider objeto)
    {
        if (objeto.CompareTag("Player"))
        {
            barraCosecha.SetActive(false);
            canvaCosecha.SetActive(false);
            triggerStayBool = false;
        }
    }

    public void ResetearTiempoCosecha()
    {
        tiempoCosecha = 0f;
        presionBoton = false;
        sliderCosecha.value = 1f;
    }
}*/

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
            barraCosecha.SetActive(true);
            float tiempoRequerido = tiempoBasePresionE * cultivosActivos;
            tiempoCosecha += Time.deltaTime;
            sliderCosecha.value = 1f - (tiempoCosecha / tiempoRequerido);

            if (tiempoCosecha >= tiempoRequerido)
            {
                CosecharCultivos();
                ResetearTiempoCosecha();
            }
        }
        else
        {
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
