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

        // Get the selected player GameObject
        GameObject selectedPlayer = Players[selectedPlayerIndex];

        // Example: Get the Player_Controller component from the selected player
        playerController = selectedPlayer.GetComponent<Player_Controller>();

        // You can now do something with the selected player
        Debug.Log("Selected Player: " + selectedPlayer.name);

        playerController.isActivePlayer = true;
        playerRotation = selectedPlayerIndex;

        cameraCine.Follow = selectedPlayer.transform;
        cameraCine.LookAt = selectedPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (roundTime >= 0)
        {
            Hourglasscontrol();
        }

        if (Input.GetKeyDown(KeyCode.E) || roundTime <= 0)
        {
            roundChanger();
        }
    }
    public void roundChanger()
    {
         roundTime = 30;
        // Deactivate the current active player
        playerController.isActivePlayer = false;

        // Increment the player index and ensure it wraps around using modulo (%)
        playerRotation = (playerRotation + 1) % Players.Length;

        // Get the next player
        GameObject selectedPlayer = Players[playerRotation];

        // Get the Player_Controller component from the selected player
        playerController = selectedPlayer.GetComponent<Player_Controller>();

        // Log the selected player
        Debug.Log("Selected Player: " + selectedPlayer.name);

        // Activate the new player
        playerController.isActivePlayer = true;

        // Update the camera to follow and look at the new player
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
