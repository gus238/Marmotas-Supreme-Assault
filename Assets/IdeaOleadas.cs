using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdeaOleadas : MonoBehaviour
{
    public int numeroOleada = 1;
    public int enemigosPorOleada;
    private int enemigosVivos;

    public GameObject enemigoPrefab;
    public Transform[] puntosDeGeneracion;

    private void Start()
    {
        IniciarOleada();
    }

    private void Update()
    {
        if (enemigosVivos <= 0)
        {
            numeroOleada++;
            IniciarOleada();
        }
    }

    private void IniciarOleada()
    {
        enemigosPorOleada = numeroOleada * 3; // Ajusta la dificultad con cada oleada
        enemigosVivos = enemigosPorOleada;

        for (int i = 0; i < enemigosPorOleada; i++)
        {
            Transform punto = puntosDeGeneracion[Random.Range(0, puntosDeGeneracion.Length)];
            GameObject enemigo = Instantiate(enemigoPrefab, punto.position, Quaternion.identity);
            //enemigo.GetComponent<Enemigo>().OnEnemyDeath += EnemigoDerrotado;
        }
    }

    private void EnemigoDerrotado()
    {
        enemigosVivos--;
    }
}

