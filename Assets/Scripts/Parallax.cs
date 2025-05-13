using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplier;
    public Transform camera;
    private Vector3 posicionAnterior;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.transform;
        posicionAnterior = camera.position;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = (camera.position.x - posicionAnterior.x) * 0.1f;
        transform.Translate(new Vector3(deltaX, 0, 0));
        posicionAnterior = camera.position;
    }
}
