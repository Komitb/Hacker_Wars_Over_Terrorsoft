using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que colisionó es un jugador
        if (other.gameObject.CompareTag("Player"))
        {
            // Cambia el puntaje
            ScoreManager.instance.ChangeScore(coinValue);

            // Destruye la moneda
            Destroy(gameObject);
        }
    }
}
