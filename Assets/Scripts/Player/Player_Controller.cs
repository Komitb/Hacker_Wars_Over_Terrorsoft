using UnityEngine;

public class Player_Controller : MonoBehaviour, IDamageable
{
    [Header("Parámetros del Jugador")]
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
   
    public float speed = 5f;       // Velocidad de movimiento horizontal
    public float jumpForce = 5f;   // Fuerza aplicada al saltar


    private Rigidbody2D rb;
    private bool isGrounded = false; // Indica si el jugador está en el suelo

    public bool isActivePlayer;

    [Header("Scripts")]
    public PlayerAimAndShoot playerAim;

    void Start()
    {
        // Obtiene el componente Rigidbody2D del jugador
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
    }

    void Update()
    {
        if (isActivePlayer == true)
        {
            playerAim.HandleGunRotation();
            playerAim.HandleGunShooting();

            // Movimiento horizontal
            float moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

            // Salto: se activa cuando se presiona la tecla "Salto" y el jugador está en el suelo
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
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
    }

    // Cuando el jugador deja de estar en contacto con el suelo, se marca como no en el suelo
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isGrounded = false;
        }
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            //Destroy(gameObject);
        }

    }
}
