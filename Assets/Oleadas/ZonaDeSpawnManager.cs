using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZonaDeSpawnManager : MonoBehaviour
{
    public GameObject pantallaVictoria;
    public GameObject prefabJefe;
    public GameObject prefabEnemigo;       // Prefab del enemigo que se va a instanciar
    public Transform[] puntosSpawn;
    public float tiempoEntreSpawn = 10f;// Tiempo entre oleadas en segundos
    public int maxOleadas = 5;             // Número máximo de oleadas
    public int enemigosPorOleada = 2;      // Número de enemigos por oleada
    public int jefePorOleada = 1;
    public int oleadaActual = 0;          // Contador de la oleada actual
    public TextMeshProUGUI enemigosRestantes;
    public TextMeshProUGUI oleadas;

    // Método Start se ejecuta al inicio
    void Start()
    {
        // Iniciar la corutina para generar oleadas
        StartCoroutine(GenerarOleadas());
    }

    // Corutina para generar oleadas de enemigos
    IEnumerator GenerarOleadas()
    {
        while (oleadaActual < maxOleadas)
        {
            // Esperar hasta que no haya enemigos vivos
            while (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
            {
                yield return new WaitForSeconds(3f);
            }
            oleadaActual++;
            Debug.Log($"¡Oleada {oleadaActual} comenzando!");
            // Generar enemigos en la posición del GameObject donde está asignado este script
            SpawnOleadaEnemigos(prefabEnemigo, (enemigosPorOleada * oleadaActual));
            if ((oleadaActual % 5) == 0 || oleadaActual == maxOleadas)
            {
                SpawnJefeFinal(prefabJefe, jefePorOleada);
            }

            yield return new WaitForSeconds(tiempoEntreSpawn);  // Espera antes de verificar nuevamente
        }
    }

    void Update()
    {
        if ((GameObject.FindGameObjectsWithTag("Enemy").Length <= 0) && oleadaActual == maxOleadas)
        {
            Time.timeScale = 0;
            pantallaVictoria.SetActive(true);
            Debug.Log("¡Todas las oleadas completadas!");

        }
        enemigosRestantes.SetText("Enemigos restantes: " + GameObject.FindGameObjectsWithTag("Enemy").Length);
        oleadas.SetText("Oleada: " + oleadaActual);

    }
    // Método para generar una oleada de enemigos
    public void SpawnOleadaEnemigos(GameObject prefabEnemigo, int cantidadEnemigos)
    {
        for (int i = 0; i < cantidadEnemigos; i++)
        {
            Transform puntoSpawn = puntosSpawn[Random.Range(0, puntosSpawn.Length)];
            Vector3 posicionSpawn = puntoSpawn.position + new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15f, 15f));
            GameObject nuevoEnemigo = Instantiate(prefabEnemigo, posicionSpawn, Quaternion.identity);
            nuevoEnemigo.SetActive(true);
            Debug.Log("Una nueva marmota ha aparecido en la zona: " + puntoSpawn);
        }
    }
    public void SpawnJefeFinal(GameObject prefabJefe, int cantidadJefe)
    {
        for (int i = 0; i < cantidadJefe; i++)
        {
            Transform puntoSpawn = puntosSpawn[Random.Range(0, puntosSpawn.Length)];
            Vector3 posicionSpawn = puntoSpawn.position + new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15f, 15f));
            GameObject nuevoJefe = Instantiate(prefabJefe, posicionSpawn, Quaternion.identity);
            nuevoJefe.SetActive(true);
            Debug.Log("Una nueva marmota ha aparecido en la zona: " + puntoSpawn);
        }
    }
}