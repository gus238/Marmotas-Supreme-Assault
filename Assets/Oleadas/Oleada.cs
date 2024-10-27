using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarOleada : MonoBehaviour
{
    public float TiempoEntreOleadas = 5f; // Tiempo de espera entre oleadas
    public int NumDeOleada = 1;          // Contador de oleadas actual

    private int EnemigosVivos = 0;       // Contador de enemigos vivos en la oleada actual
    private bool OleadaEnProceso = false; // Indica si una oleada est� en progreso

    void Update()
    {
        // Verifica si no hay enemigos vivos y si la oleada est� activa
        if (OleadaEnProceso && EnemigosVivos <= 0)
        {
            OleadaEnProceso = false; // Marca que la oleada ha terminado
            StartCoroutine(SiguienteOleada()); // Inicia la siguiente oleada despu�s del tiempo de espera
        }
    }

    IEnumerator SiguienteOleada()
    {
        yield return new WaitForSeconds(TiempoEntreOleadas); // Espera antes de la pr�xima oleada

        NumDeOleada++; // Incrementa el contador de oleadas
        OleadaEnProceso = true; // Marca que la nueva oleada ha comenzado

        // Llama a tu sistema de spawn para generar enemigos de la nueva oleada
        SpawnEnemigosPorOleada(NumDeOleada);
    }

    // Llama a este m�todo cuando un enemigo es generado
    public void OnEnemySpawned()
    {
        EnemigosVivos++;
    }

    // Llama a este m�todo cuando un enemigo muere
    public void OnEnemyKilled()
    {
        EnemigosVivos--;
    }

    // Funci�n para generar enemigos, puedes personalizarla seg�n el dise�o de tu sistema de spawn
    private void SpawnEnemigosPorOleada(int wave)
    {
        // Ejemplo: llama a tu sistema de spawn y env�a la cantidad de enemigos seg�n la oleada
        // Aqu� podr�as usar diferentes cantidades o tipos de enemigos seg�n el n�mero de oleada.
        int enemyCount = wave * 2; // Por ejemplo, el doble de enemigos por cada oleada
        for (int i = 0; i < enemyCount; i++)
        {
            // Aqu� puedes llamar a tu sistema de spawn de enemigos
            // Ejemplo: spawnManager.SpawnEnemy();
            OnEnemySpawned();
        }
    }
}