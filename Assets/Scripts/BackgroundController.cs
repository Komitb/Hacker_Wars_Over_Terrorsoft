using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startPos;
    public GameObject cam;
    public float parallaxEffect; // La velocidad en la que el fondo debería moverse relativamente a la cámara.
    // Start is called before the first frame update

    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula la distancia recorrida por el fondo en base en el movimiento de la camara
        float distance = cam.transform.position.x * parallaxEffect; // 0 = fondo se mueve con la camara || 0.5 = la mitad || 1 = no se moverá

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
