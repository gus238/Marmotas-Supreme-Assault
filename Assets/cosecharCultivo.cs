using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class cosecharCultivo : MonoBehaviour
{
    public GameObject[] cultivosListosParaCosechar;
    public GameObject canvaCosecha;
    private float tiempoCosecha;
    public float tiempoDePresionE = 3.0f;
    private bool presionBoton;
    private bool triggerStayBool;
    public GameObject barraCosecha;
    public Slider sliderCosecha;


    void Start()
    {
        barraCosecha.SetActive(false);
        triggerStayBool = false;
        presionBoton = false;
        canvaCosecha.SetActive(false);
        sliderCosecha.value = 1f;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && triggerStayBool)
        {
            barraCosecha.SetActive(true);
            tiempoCosecha += Time.deltaTime;
            sliderCosecha.value = 1f - (tiempoCosecha / tiempoDePresionE);

            if (tiempoCosecha >= tiempoDePresionE)
            {
                Debug.Log("OwO");
                tiempoCosecha = 0f;
                presionBoton = true;
                sliderCosecha.value = 1f;
                barraCosecha.SetActive(false);
            }
        }
        else
        {
            barraCosecha.SetActive(false);
            tiempoCosecha = 0f;
        }
    }

    void OnTriggerStay(Collider objeto)
    {
        if (objeto.tag == "Player")
        {
            canvaCosecha.SetActive(true);
            triggerStayBool = true;
            for (int i = 0; i < cultivosListosParaCosechar.Length; i++)
            {
                if (cultivosListosParaCosechar[i].activeSelf && presionBoton)
                {
                    cosechaCultivo cultivoListo = cultivosListosParaCosechar[i].GetComponent<cosechaCultivo>();
                    cultivoListo.DarDinero();
                    tiempoDePresionE = tiempoDePresionE * 2;
                    cultivosListosParaCosechar[i].SetActive(false);
                }
            }


            
        }
    }
    void OnTriggerExit(Collider objeto)
    {
        barraCosecha.SetActive(false);
        canvaCosecha.SetActive(false);
        triggerStayBool = false;
    }
}
