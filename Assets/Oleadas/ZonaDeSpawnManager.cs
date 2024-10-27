using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDeSpawnManager : MonoBehaviour
{
    public GameObject prefabEnemigo;       // Prefab del enemigo que se va a instanciar
    public float tiempoEntreSpawn = 5f;      // Tiempo entre spawns en segundos
    public int maxOleadas = 5;                // Número máximo de oleadas
    public int enemigosPorOleada = 5;         // Número de enemigos por oleada
    private int oleadaActual = 0;             // Contador de la oleada actual

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
            oleadaActual++;
            Debug.Log($"¡Oleada {oleadaActual} comenzando!");

            // Generar enemigos en la posición del GameObject donde está asignado este script
            SpawnOleadaEnemigos(prefabEnemigo, enemigosPorOleada);

            // Esperar un tiempo antes de la siguiente oleada
            yield return new WaitForSeconds(tiempoEntreSpawn);
        }
    }

    // Método para generar una oleada de enemigos
    public void SpawnOleadaEnemigos(GameObject prefabEnemigo, int cantidadEnemigos)
    {
        for (int i = 0; i < cantidadEnemigos; i++)
        {
            // Generar enemigos en la posición del GameObject, con un pequeño desplazamiento aleatorio
            Vector3 posicionSpawn = transform.position + new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
            GameObject nuevoEnemigo = Instantiate(prefabEnemigo, posicionSpawn, Quaternion.identity);
            Debug.Log("Una nueva marmota ha aparecido en la zona.");
        }
    }
}