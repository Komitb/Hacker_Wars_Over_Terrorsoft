using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class RNG_Controller : MonoBehaviour
{
    public GameObject[] Players; // El array que contiene a los jugadores

    Player_Controller playerController; 

    public CinemachineCamera cameraCine;

    int selectedPlayerIndex;
    int playerRotation;

    float timer; // Cuenta el time delta time
    public int roundTime; // El temporizador que cuenta el tiempo restante del jugador
    public float timerSeconds = 1; // Cuenta los segundos de uno en uno (si cambias esto el timer baja en lo que le pongas)

    void Start()
    {
        roundTime = 30; // tiempo de la ronda
        // Elige un player aleatorio entre 0 y la cantidad de players que hay en el array (ahora mismo 4)
        selectedPlayerIndex = UnityEngine.Random.Range(0, Players.Length);

        // Seteas "SelectedPlayer" para acceder a su script
        GameObject selectedPlayer = Players[selectedPlayerIndex];

        // Setea "playerController" como el script del jugador activo
        playerController = selectedPlayer.GetComponent<Player_Controller>();

        Debug.Log("Selected Player: " + selectedPlayer.name);

        // Cambia el booleano "isActivePlayer" a true
        playerController.isActivePlayer = true;
        playerRotation = selectedPlayerIndex;

        // Hace que la camara siga al jugador activo
        cameraCine.Follow = selectedPlayer.transform;
        cameraCine.LookAt = selectedPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // El timer
        timer += Time.deltaTime;
        if (roundTime >= 0)
        {
            Hourglasscontrol();
        }
        //Para testear el round changer (E) y cuando acaba el tiempo tambien cambia de ronda
        if (Input.GetKeyDown(KeyCode.E) || roundTime <= 0)
        {
            roundChanger();
        }
    }
    public void roundChanger()
    {
        // Reinicia el timer  de la ronda
         roundTime = 30;
        // Desactiva el jugador actual
        playerController.isActivePlayer = false;
        // Selecciona el jugador siguiente en el array
        playerRotation = (playerRotation + 1) % Players.Length;
        // Setea seletedPlayer al jugador actual
        GameObject selectedPlayer = Players[playerRotation];
        // Accede al script del jugador actual
        playerController = selectedPlayer.GetComponent<Player_Controller>();
        Debug.Log("Selected Player: " + selectedPlayer.name);
        // Activa el jugador actual
        playerController.isActivePlayer = true;
        // Actualiza el movimineto de la camara (referencia)
        cameraCine.Follow = selectedPlayer.transform;
        cameraCine.LookAt = selectedPlayer.transform;
    }
    public void Hourglasscontrol()
    {
        if (timer > timerSeconds)
        {
            roundTime--;
            timer = 0;
        }
    }
}
