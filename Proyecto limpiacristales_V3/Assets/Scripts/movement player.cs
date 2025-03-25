using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementplayer : MonoBehaviour
{
    public float vel=5f;
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()//Movimiento del personaje de izquierda a derecha
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3 (horizontal, 0f, vertical) *vel* Time.deltaTime;
        transform.Translate(movimiento, Space.World);

    }
}
