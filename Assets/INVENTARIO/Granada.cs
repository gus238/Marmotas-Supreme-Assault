using System.Collections;
using UnityEngine;

public class Granada : MonoBehaviour
{
    [Header("Propiedades de la Granada")]
    public int daño = 100;
    public float radioExplosion = 5f;
    public float tiempoExplosion = 3f;

    [Header("Referencias")]
    public GameObject efectoExplosion;
    public LayerMask enemigosLayer;

    private void Start()
    {
        Invoke(nameof(Explotar), tiempoExplosion);
    }

    private void Explotar()
    {
        Collider[] enemigos = Physics.OverlapSphere(transform.position, radioExplosion, enemigosLayer);

        foreach (Collider enemigo in enemigos)
        {
            VidaEnemigo vidaEnemigo = enemigo.GetComponent<VidaEnemigo>();
            if (vidaEnemigo != null)
            {
                vidaEnemigo.TakeDamage(daño);
            }
        }

        Instantiate(efectoExplosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

