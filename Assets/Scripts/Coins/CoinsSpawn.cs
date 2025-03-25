using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawn : MonoBehaviour
{
    public GameObject coinsSpawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnCoins", 0f, 30f); //Aqui repetimos cada 30s el spawn de la moneda
    }

    Vector2 GetSpawnPoint() //Nos da la posicion de spawn de la moneda
    {
        float x = Random.Range(-20f, 20f);
        float y = Random.Range(1f, 8f);

        return new Vector2(x, y);
    }
    void SpawnCoins() //Instancia la coin
    {
        Instantiate(coinsSpawn, GetSpawnPoint(), Quaternion.identity);
    }
}
