using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


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

    public GameObject player;
    public float timeLimit = 20f; 
    public float currentTime;
    public float timeToAdd;

   
   

    [Header("Scripts")]
    public PlayerAimAndShoot playerAim;

    void Start()
    {
        // Obtiene el componente Rigidbody2D del jugador
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        //Le dice cual es el límite del tiempo para que pueda bajar el value
         currentTime = timeLimit; 
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
            if (currentTime > 0)
            {
              currentTime -= Time.deltaTime;
              //timeslider.value = currentTime;
            }
            if (currentTime <= 0)
            {
              //player.SetActive(false);
            }
        }
    }
    public void Sumartiempo()//Función que usa el control de la olla para sumar tiempo al player
    {
        Debug.Log(currentTime+" "+timeToAdd);
        currentTime += timeToAdd;
        if (currentTime > timeLimit)// Para que cuando sume no se pase del tiempo límite del player
        {
            currentTime = timeLimit;
        }
        Debug.Log(currentTime);
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
