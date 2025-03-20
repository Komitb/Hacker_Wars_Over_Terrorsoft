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
    private float chargeSpeed;
    private bool charging;
    private bool isWaitingForNextRound = false;

    [Header("Disparos")]
    [SerializeField] private int maxShots = 2; // Número máximo de disparos permitidos
    private int numOfShots;

    [Header("Scripts")]
    public Player_Controller player_Controller;
    public RNG_Controller rng_Controller;
    public BulletBehaviour bulletBehaviour;


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

        if (Input.GetMouseButtonDown(0) && numOfShots > 0)
        {
            bulletBehaviour.physicsBulletSpeed = 0f;
            charging = true;
            Debug.Log("Pulado");
        }
        if (Input.GetMouseButtonUp(0))
        {
            numOfShots--;
            bulletBehaviour.physicsBulletSpeed = chargeSpeed;
            bulletInst = Instantiate(bullet, bulletSpawnPoint.position, gun.transform.rotation);
            Debug.Log("Soltado con una fuerza de " + chargeSpeed);
            charging = false;
        }
        if (charging)
        {
           chargeSpeed = bulletBehaviour.physicsBulletSpeed += 10f * Time.deltaTime;
        }
        if (numOfShots == 0)
        {
            // Si se han agotado los disparos, cambiar de turno
            player_Controller.speed = 0; // Desactivar el movimiento del jugador al disparar
            StartCoroutine(WaitAndChangeRound());
        }
    }


    private IEnumerator WaitAndChangeRound()
    {
        if (isWaitingForNextRound)
            yield break;  // Si ya está en ejecución, no lo llamamos de nuevo.

        isWaitingForNextRound = true;

        yield return new WaitForSeconds(2f); // Esperar 2 segundos
        rng_Controller.roundChanger();  // Cambiar el turno
        numOfShots = maxShots; // Resetear el contador de disparos para el siguiente turno
        player_Controller.speed = 5f; // Volver a activar el movimiento del jugador

        isWaitingForNextRound = false; // Termina la corrutina
    }
}
