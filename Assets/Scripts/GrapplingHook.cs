using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    [SerializeField] private float grappleLength; // Distancia a la que llega el gancho
    [SerializeField] private float stretchTo; // La distancia a la que el gancho se queda de la pared al empujarte a ella
    [SerializeField] private LayerMask grappleLayer; //Capa para el gancho
    [SerializeField] private LineRenderer rope; // El objeto que renderiza la "Cuerda" en tiempo real
    [SerializeField] private float ropeMissVisibleDuration = 0.3f; // Tiempo en segundos en el que la cuerda se ve cuando fallas a una pared/suelo

    private Vector3 grapplePoint;
    private DistanceJoint2D joint;
    private bool isGrappling = false; // Este booleano se activa cuando estas enganchado a algo
    private Coroutine hideCoroutine = null; 
    Window_Controller windowc;
    void Start()
    {
        windowc = FindAnyObjectByType<Window_Controller>();
        joint = gameObject.GetComponent<DistanceJoint2D>();
        if (joint == null)
        {
            Debug.LogError("No hay gancho", this);
            // joint = gameObject.AddComponent<DistanceJoint2D>();
        }
        joint.enabled = false;
        rope.enabled = false;
        joint.autoConfigureDistance = false;
    }

    void Update()
    {
        // Lanzamiento del gancho
        if (Input.GetMouseButtonDown(0) && windowc.ventanaon==false)
        {
            // Para cuaquier corrutina antes de lanzar el gancho
            if (hideCoroutine != null)
            {
                StopCoroutine(hideCoroutine);
                hideCoroutine = null;
            }
            if (isGrappling)
            {
                joint.enabled = false;
                isGrappling = false;
            }


            // Calcula donde tiene que lanzarse el gancho
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0;
            Vector3 currentPosition = transform.position; // Save position at the moment of firing
            Vector2 direction = (mouseWorldPos - currentPosition).normalized;

            // Genera el "RayCast"
            RaycastHit2D hit = Physics2D.Raycast(
                origin: currentPosition,
                direction: direction,
                distance: grappleLength,
                layerMask: grappleLayer
            );

            Vector3 ropeEndPoint; // Donde acaba la cuerda

            // Cuando el gancho conecta
            if (hit.collider != null)
            {
                grapplePoint = hit.point;
                ropeEndPoint = grapplePoint;

                joint.connectedAnchor = grapplePoint;
                joint.distance = stretchTo;
                joint.enabled = true;
                isGrappling = true; 
            }
            else //Cuando el gancho no conecta
            {
                ropeEndPoint = currentPosition + (Vector3)direction * grappleLength; // La cuerda llega a su distancia maxima y se acaba
                isGrappling = false;
                joint.enabled = false; 

                hideCoroutine = StartCoroutine(HideRopeAfterDelay(ropeMissVisibleDuration));
            }

            // Esto hace que la cuerda se muestre cuando la fallas para dar feedback visual de que has lanzado la cuerda pero no la ha acertado
            rope.SetPosition(0, ropeEndPoint);   
            rope.SetPosition(1, currentPosition); 
            rope.enabled = true;    
        }

        // Este codigo hace que cuando sueltes el boton del raton se quita la cuerda
        if (Input.GetMouseButtonUp(0))
        {
            if (hideCoroutine != null)
            {
                StopCoroutine(hideCoroutine);
                hideCoroutine = null;
            }

            if (isGrappling)
            {
                joint.enabled = false;
                isGrappling = false;
            }
            rope.enabled = false;
        }

        //Este codigo hace que la cuerda se actualice moviendose con el jugador
        if (rope.enabled)
        {
            rope.SetPosition(1, transform.position);

            if (isGrappling)
            {
                rope.SetPosition(0, grapplePoint);
            }
        }
    }


    IEnumerator HideRopeAfterDelay(float delay) // Espera si has fallado la cuerda y oculta la cuerda si es false
    {
        yield return new WaitForSeconds(delay);

        if (!isGrappling && rope.enabled)
        {
            rope.enabled = false;
        }
        hideCoroutine = null;
    }
}