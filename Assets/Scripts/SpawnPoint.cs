using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    //Punto de Aparición de cada equipo del juego
    public GameObject[] playerPrefabs;

    // Start is called before the first frame update
    void Start() //LLamamos al SpawnObject para generar el objeto asociado a cada equipo
    {
        for (int i = 0; i < playerPrefabs.Length; i++)
        {
            SpawnObject(playerPrefabs[i]); // Spawnea el jugador en el punto correspondiente
        }
    }

    Vector2 GetSpawnPoint() //Decimos el rango maximo donde se podran generar los objetos entre los ejes x, y.
    {
        float x = Random.Range(-26f, 31f);
        float y = Random.Range(1f, 8f);

        return new Vector2(x, y);
    }

    void SpawnObject(GameObject playerPrefab)
    {
        // Obtén un punto de spawn aleatorio
        Vector2 spawnPos = GetSpawnPoint();

        // Instancia el jugador en la posición aleatoria con rotación inicial de 0
        Instantiate(playerPrefab, spawnPos, Quaternion.identity);
    }
}
