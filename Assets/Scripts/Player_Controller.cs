using System.Collections;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [Header("Parámetros de Movimiento")]
    public float speed = 5f;       // Velocidad de movimiento horizontal
    public float jumpForce = 5f;   // Fuerza aplicada al saltar
    public bool useTransformMovement;

    private Rigidbody2D rb;
    private bool isGrounded = false; // Indica si el jugador está en el suelo

    Window_Controller window;
    void Start()
    {
        window = FindObjectOfType<Window_Controller>();
        // Obtiene el componente Rigidbody2D del jugador
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float x = Input.GetAxis("Horizontal");

        // Salto: se activa cuando se presiona la tecla "Salto" y el jugador está en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;    
        }

        if (useTransformMovement == false)
        {

            rb.velocity = new Vector3(x, rb.velocity.y, 0);

        }
        else
        {
            transform.position = new Vector3 (transform.position.x + x * Time.deltaTime * speed, transform.position.y, transform.position.z);
        }
    }

    // Comprueba si el jugador está en contacto con el suelo mediante colisiones
    void OnCollisionEnter2D(Collision2D collision)
    {
        // El suelo debe tener la etiqueta "Ground"
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Void"))
        {
            transform.position = new Vector3(0, 0, 0); 
        }
    }

    // Cuando el jugador deja de estar en contacto con el suelo, se marca como no en el suelo
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }
    void OnTriggerEnter2D(Collider2D banderon)
    {
        
        if (banderon.gameObject.CompareTag("Bandera"))
        {
            Debug.Log("nsafnaf");
            window.ventana();
            speed = 0;
        }
    }
}
