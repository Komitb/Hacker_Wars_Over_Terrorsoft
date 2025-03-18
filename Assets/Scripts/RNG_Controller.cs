using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;

public class RNG_Controller : MonoBehaviour
{
    public GameObject[] playerPrefabs; // Array de los prefabs de los jugadores
    public GameObject[] Players; // Array de jugadores instanciados
    public CinemachineCamera cameraCine; // Cámara para seguir al jugador seleccionado

    private Player_Controller playerController; // El controlador del jugador activo
    private int selectedPlayerIndex; // Índice del jugador seleccionado
    private int playerRotation; // Índice para las rondas de cambio de jugador
    private float timer; // Temporizador para las rondas
    public int roundTime; // Tiempo de ronda
    public float timerSeconds = 1; // Tiempo de decremento de ronda

    void Start()
    {
        roundTime = 30;

        // Instancia los jugadores
        SpawnPlayers();

        // Si hay jugadores instanciados, selecciona uno aleatorio
        if (Players.Length > 0)
        {
            SelectRandomPlayer();
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
        SelectRandomPlayer();
    }

    // Función que selecciona un jugador aleatorio para la ronda
    void SelectRandomPlayer()
    {
        // Selecciona un jugador aleatorio
        selectedPlayerIndex = UnityEngine.Random.Range(0, Players.Length);

        // Obtiene el jugador seleccionado
        GameObject selectedPlayer = Players[selectedPlayerIndex];

        // Obtiene el controlador del jugador
        playerController = selectedPlayer.GetComponent<Player_Controller>();

        // Marca al jugador como activo
        playerController.isActivePlayer = true;
        playerRotation = selectedPlayerIndex;

        // La cámara seguirá al jugador seleccionado
        cameraCine.Follow = selectedPlayer.transform;
        cameraCine.LookAt = selectedPlayer.transform;
    }

    // Esta función controla el temporizador de la ronda
    public void Hourglasscontrol()
    {
        if (timer > timerSeconds)
        {
            roundTime--;
            timer = 0;
        }
    }

    // Función para instanciar los jugadores en la escena
    void SpawnPlayers()
    {
        Players = new GameObject[playerPrefabs.Length];

        for (int i = 0; i < playerPrefabs.Length; i++)
        {
            Vector2 spawnPos = new Vector2(UnityEngine.Random.Range(-26f, 31f), UnityEngine.Random.Range(1f, 8f));
            Players[i] = Instantiate(playerPrefabs[i], spawnPos, Quaternion.identity);
        }
    }
}

