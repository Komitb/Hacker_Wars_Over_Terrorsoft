using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText; // Referencia al texto UI
    private int sc = 0; // Puntuación inicial
    private Player_Controller playerController;

    void Awake()
    {
        playerController = FindFirstObjectByType<Player_Controller>();
        // Asegurar que solo haya una instancia del ScoreManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int points) //Añade los puntos de las coins globales
    {
        //score += points;
        UpdateScoreUI();
    }

    void UpdateScoreUI() //Actualiza el texto del score
    {
    //    scoreText.text = "Score: " + score;
    }
}

