using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawn : MonoBehaviour
{
    public GameObject coinsSpawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoins", 0f, 30f);
    }

    Vector2 GetSpawnPoint()
    {
        float x = Random.Range(-26f, 31f);
        float y = Random.Range(1f, 8f);

        return new Vector2(x, y);
    }
    void SpawnCoins()
    {
        Instantiate(coinsSpawn, GetSpawnPoint(), Quaternion.identity);
    }
}
