using TMPro;
using UnityEngine;
using UnityEngine.UI; // Necesario para trabajar con la UI

public class Player_Controller : MonoBehaviour
{
    [Header("Parámetros de Movimiento")]
    public float speed = 5f;       // Velocidad de movimiento horizontal
    public float jumpForce = 5f;   // Fuerza aplicada al saltar

    private Rigidbody2D rb;
    private bool isGrounded = false; // Indica si el jugador está en el suelo

    public bool isActivePlayer;
    public int playerScore; // Puntaje del jugador
    public TextMeshProUGUI scoreText;  // El texto de la UI que mostrará el puntaje del jugador

    void Start()
    {
        // Obtiene el componente Rigidbody2D del jugador
        rb = GetComponent<Rigidbody2D>();

        // Actualiza el puntaje en la UI al comenzar
        UpdateScoreText();
    }

    void Update()
    {
        if (isActivePlayer)
        {
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

        // Si el jugador colisiona con una moneda
        if (collision.gameObject.CompareTag("Coins"))
        {
            CollectCoin(collision.gameObject);
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

    // Método para recoger la moneda
    void CollectCoin(GameObject coin)
    {
        // Si el jugador está activo, incrementa el puntaje
        if (isActivePlayer)
        {
            // Incrementa el puntaje
            playerScore += 1;

            // Actualiza el puntaje en la UI
            UpdateScoreText();

            // Destruye la moneda
            Destroy(coin);
        }
    }

    // Método para actualizar el texto del puntaje en la UI
    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + playerScore.ToString();
        }
    }
}

