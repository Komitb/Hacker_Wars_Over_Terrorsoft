using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float time = 45; //Tiempo con el que se inicia
    public TextMeshProUGUI timeText; //Texto para mostrar el tiempo
    private bool isGameOver = false; //Marca si ha terminado el juego
    public GameObject losePanel; //Panel que muestra el panel de derrota

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        losePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver) //Si el juego no ha terminado
        {
            time -= Time.deltaTime; //Resta tiempo en cada segundo real que pasa
            if (time <= 0) //Si llega a 0, se termina el juego y nos saca el panel de derrota
            {
                time = 0;
                isGameOver = true;
                LoserPanel();
                Time.timeScale = 0; 
            }
            TimerDisplay(); //Actualiza el texto con el tiempo actual del jhuego
        }
    }

    void TimerDisplay() //Muestra el tiempo actualizado en pantalla
    {
        if (timeText != null)
        {
            timeText.text = "Time: " + time.ToString("F2");
        }
    }

    public void LoserPanel() //Activa el panel de derrota
    {
        losePanel.SetActive(true);

    }

    public void RestartButton() //Reinicia la escena actual
    {
        SceneManager.LoadScene("MainGame");
    }

    public void AddTime(float seconds) //Añade segundos al timepo
    {
        time += seconds;
        TimerDisplay();
    }
}


