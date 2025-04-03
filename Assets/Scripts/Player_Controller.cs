using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [Header("Par�metros de Movimiento")]
    public float speed = 5f;       // Velocidad de movimiento horizontal
    public float jumpForce = 5f;   // Fuerza aplicada al saltar
    public bool useTransformMovement;

    private Rigidbody2D rb;
    private bool isGrounded = false; // Indica si el jugador est� en el suelo

    void Start()
    {
        // Obtiene el componente Rigidbody2D del jugador
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float x = Input.GetAxis("Horizontal");

        // Salto: se activa cuando se presiona la tecla "Salto" y el jugador est� en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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

    // Comprueba si el jugador est� en contacto con el suelo mediante colisiones
    void OnCollisionEnter2D(Collision2D collision)
    {
        // El suelo debe tener la etiqueta "Ground"
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = true;
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
}
