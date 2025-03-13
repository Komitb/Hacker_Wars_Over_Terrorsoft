using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class RNG_Controller : MonoBehaviour
{
    public GameObject[] Players; // Array de jugadores instanciados

    Player_Controller playerController; // Asumimos que tienes un Player_Controller para cada jugador

    public CinemachineCamera cameraCine; // Cámara para seguir al jugador seleccionado

    int selectedPlayerIndex;
    int playerRotation;

    float timer;
    public int roundTime;
    public float timerSeconds = 1;

    void Start()
    {
        roundTime = 30;

        // Busca todos los objetos con la etiqueta "Player" (o el tag que hayas asignado a los jugadores)
        Players = GameObject.FindGameObjectsWithTag("Player");

        // Si hay jugadores, selecciona uno aleatorio
        if (Players.Length > 0)
        {
            // Selecciona un jugador aleatorio
            selectedPlayerIndex = UnityEngine.Random.Range(0, Players.Length);

            // Obtiene el jugador seleccionado
            GameObject selectedPlayer = Players[selectedPlayerIndex];

            // Obtiene el controlador del jugador
            playerController = selectedPlayer.GetComponent<Player_Controller>();

            Debug.Log("Selected Player: " + selectedPlayer.name);

            // Marca al jugador como activo
            playerController.isActivePlayer = true;
            playerRotation = selectedPlayerIndex;

            // La cámara seguirá al jugador seleccionado
            cameraCine.Follow = selectedPlayer.transform;
            cameraCine.LookAt = selectedPlayer.transform;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (roundTime >= 0)
        {
            Hourglasscontrol(); // Controla el temporizador
        }

        if (Input.GetKeyDown(KeyCode.E) || roundTime <= 0)
        {
            roundChanger(); // Cambia de ronda cuando se presiona E o se acaba el tiempo
        }
    }

    void roundChanger()
    {
        roundTime = 30;

        // Desactiva al jugador actual
        playerController.isActivePlayer = false;

        // Incrementa el índice del jugador de forma cíclica (utilizando %)
        playerRotation = (playerRotation + 1) % Players.Length;

        // Obtiene el siguiente jugador
        GameObject selectedPlayer = Players[playerRotation];
        playerController = selectedPlayer.GetComponent<Player_Controller>();

        Debug.Log("Selected Player: " + selectedPlayer.name);

        // Marca al nuevo jugador como activo
        playerController.isActivePlayer = true;

        // Actualiza la cámara para que siga al nuevo jugador
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
