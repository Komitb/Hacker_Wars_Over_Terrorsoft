using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour
{
    public float normalspeed = 0.10f;
    public float boostedspeed=2f;
    private float currentspeed;
    private float direction = 1f;
    public GameObject player;

    // Start is called before the first frame update
    void Start()//Velocidad de la cámara al inicio
    {
        currentspeed=normalspeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.parent.Translate(Vector3.right * currentspeed * direction * Time.deltaTime);//Moviemto de la cámara según la posición del player
        if (transform.parent.position.x >= 10f)
        {
            direction = -1f;
        }
        else if (transform.parent.position.x <= -10f)
       {
         direction = 1f;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)//Cuando el player enre en el collider que aumente su velocidad
    {
        if (other.CompareTag("player"))
        {
            Debug.Log("entro" + other.name);
            currentspeed = boostedspeed;

        }
        
    }
    
    public void OnTriggerExit2D(Collider2D other)//Cuando el player salga del collider que vuelva a su velocidad normal
    {
        if (other.CompareTag("player"))
        {
            currentspeed= normalspeed;
        }
    }
}
