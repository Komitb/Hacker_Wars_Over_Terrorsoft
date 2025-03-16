using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class RNG_Controller : MonoBehaviour
{
    public GameObject[] Players; // Array of players

    Player_Controller playerController; // Assuming you have a Player_Controller class

    public CinemachineCamera cameraCine;

    int selectedPlayerIndex;
    int playerRotation;

    float timer;
    public int roundTime;
    public float timerSeconds = 1;

    void Start()
    {
        roundTime = 30;
        // Pick a random player index from the Players array
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
