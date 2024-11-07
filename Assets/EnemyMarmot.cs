using UnityEngine;

public class EnemyMarmot : MonoBehaviour
{
    public int coinAmount = 5; // Cantidad de monedas que esta marmota específica dará al morir

    void OnDeath()
    {
        GrantCoinsToPlayer();
        Destroy(gameObject); // Destruye la marmota al morir
    }

    void GrantCoinsToPlayer()
    {
        Debug.Log("Has ganado " + coinAmount + " monedas al matar una marmota.");
    }
}
