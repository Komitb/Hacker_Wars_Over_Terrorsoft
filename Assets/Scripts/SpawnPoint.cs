using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Referencia al prefab de jugador �nico
    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject(); // Llama a la funci�n para spawnear el jugador en el punto correspondiente
    }

    Vector2 GetSpawnPoint() // Define el rango m�ximo de generaci�n de objetos entre los ejes X e Y.
    {
        float x = Random.Range(-26f, 31f);
        float y = Random.Range(1f, 8f);

        return new Vector2(x, y);
    }

    void SpawnObject()
    {
        // Obt�n un punto de spawn aleatorio
        Vector2 spawnPos = GetSpawnPoint();

        // Instancia un jugador en la posici�n aleatoria con rotaci�n inicial de 0
        Instantiate(playerPrefab, spawnPos, Quaternion.identity);
    }
}
