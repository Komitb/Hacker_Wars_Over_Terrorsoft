using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoit : MonoBehaviour
{
    public GameObject[] players;
    public List<GameObject> floors;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    // Start is called before the first frame update
    void Start()
    {
        GenerateTerrain();
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
    void GenerateTerrain()
    {
        bool terrainType = true;
        for(int i = 0; i < 50; i++)
        {
            float xpos = 12.7f*i;
            int type = 0;
            if (terrainType == false)
            {
                type = 1;
            }
            Instantiate(floors[type],new Vector3(-30+xpos,-5.5f,0),Quaternion.identity);
            terrainType = !terrainType;
        }
    }
}
