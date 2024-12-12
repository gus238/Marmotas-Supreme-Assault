using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasarOleada : MonoBehaviour
{
    public float TiempoEntreOleadas = 5f; 
    public int NumDeOleada = 1;          // Contador de oleadas actual

    private int EnemigosVivos = 0;       
    private bool OleadaEnProceso = false; 

    void Update()
    {
        // Verifica si no hay enemigos vivos y si la oleada esta activa
        if (OleadaEnProceso && EnemigosVivos <= 0)
        {
            OleadaEnProceso = false; 
            StartCoroutine(SiguienteOleada()); // Inicia la siguiente oleada despues del tiempo de espera
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

    // Llama a este metodo cuando un enemigo es generado
    public void OnEnemySpawned()
    {
        EnemigosVivos++;
    }

    // Llama a este metodo cuando un enemigo muere
    public void OnEnemyKilled()
    {
        EnemigosVivos--;
    }

    // Funcion para generar enemigos
    private void SpawnEnemigosPorOleada(int wave)
    {
        int enemyCount = wave * 2; // Crea el doble de enemigos por cada oleada que pase
        for (int i = 0; i < enemyCount; i++)
        {

            OnEnemySpawned();
        }
    }
}