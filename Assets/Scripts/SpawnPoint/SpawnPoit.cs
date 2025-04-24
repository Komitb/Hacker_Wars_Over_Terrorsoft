using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPoit : MonoBehaviour
{
    public GameObject[] players;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    // Start is called before the first frame update
    void Start()
    {
      SpawnPoint(); //Llamamos al Spawn de los jugadores antes del primer frame
    }
   
    void SpawnPoint()
    {
       
        foreach (GameObject player in players)
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(minPosition.x, maxPosition.x),
                Random.Range(minPosition.y, maxPosition.y)
                // Genera una posicion aleatoria de los limites que hemos establecido en el inspector
            );

            player.transform.position = randomPosition; // Asigna la posicion aleatoria generada al jugador actual en bucle
            player.SetActive(true); // Activa el jugador en la escena
        }
    }
}
