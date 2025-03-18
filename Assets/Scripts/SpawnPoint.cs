using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Referencia al prefab de jugador único
    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject(); // Llama a la función para spawnear el jugador en el punto correspondiente
    }

    Vector2 GetSpawnPoint() // Define el rango máximo de generación de objetos entre los ejes X e Y.
    {
        float x = Random.Range(-26f, 31f);
        float y = Random.Range(1f, 8f);

        return new Vector2(x, y);
    }

    void SpawnObject()
    {
        // Obtén un punto de spawn aleatorio
        Vector2 spawnPos = GetSpawnPoint();

        // Instancia un jugador en la posición aleatoria con rotación inicial de 0
        Instantiate(playerPrefab, spawnPos, Quaternion.identity);
    }
}
