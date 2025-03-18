using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAimAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawnPoint;

    private GameObject bulletInst;

    private Vector2 worldPosition;
    private Vector2 direction;
    private float angle;

    [Header("Disparos")]
    [SerializeField] private int maxShots = 2; // Número máximo de disparos permitidos
    private int numOfShots;

    [Header("Scripts")]
    public Player_Controller player_Controller;
    public RNG_Controller rng_Controller;

    private void Start()
    {
        numOfShots = maxShots; // Inicializamos el contador de disparos
    }

    private void Update()
    {
        
    }

    public void HandleGunRotation()
    {
        // Rotar el arma hacia la posición del ratón
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)gun.transform.position).normalized;
        gun.transform.right = direction;

        // Dar la vuelta al sprite del arma cuando llega a un limite de 90º
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Vector3 localScale = new Vector3(1f, 1f, 1f);
        if (angle > 90 || angle < -90)
        {
            localScale.y = -1f;
        }
        else
        {
            localScale.y = 1f;
        }

        gun.transform.localScale = localScale;
    }

    public void HandleGunShooting()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && numOfShots > 0)
        {
            // Disparar el arma si quedan disparos
            numOfShots--;
            bulletInst = Instantiate(bullet, bulletSpawnPoint.position, gun.transform.rotation);
            if (numOfShots == 0)
            {
                // Si se han agotado los disparos, cambiar de turno
                player_Controller.speed = 0; // Desactivar el movimiento del jugador al disparar
                StartCoroutine(WaitAndChangeRound());
            }
        }
    }

    private IEnumerator WaitAndChangeRound() // Nabegos no esta de acuerdo
    {
        yield return new WaitForSeconds(2f); // Esperar 2 segundos, cambiar de ronda y desbloquear al jugador cuando vuelva a ser su turno.
        rng_Controller.roundChanger();  // Cambiar el turno
        numOfShots = maxShots; // Resetear el contador de disparos para el siguiente turno
        player_Controller.speed = 5f; // Volver a activar el movimiento del jugador
    }
}
