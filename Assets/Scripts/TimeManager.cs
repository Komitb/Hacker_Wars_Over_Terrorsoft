using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float time = 45;
    public TextMeshProUGUI timeText;
    private bool isGameOver = false;
    public GameObject losePanel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        losePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
                isGameOver = true;
                LoserPanel();
                Time.timeScale = 0; 
            }
            TimerDisplay();
        }
    }

    void TimerDisplay()
    {
        if (timeText != null)
        {
            timeText.text = "Time: " + time.ToString("F2");
        }
    }

    public void LoserPanel()
    {
        losePanel.SetActive(true);

    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MainGame");
    }
}
