using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civil : MonoBehaviour
{
    GameObject civil; //Referencia al civil

    Player_Controller player;
    TimeManager timeManager;

    private void Start()
    {
        player = FindAnyObjectByType<Player_Controller>();
        timeManager = FindAnyObjectByType<TimeManager>();
    }

    //Si el civil ya rescatado entra en el trigger de la bandera de la base principal, se para el juego y sale el panel como juego terminado, ademas de destruir la bandera
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BanderaWin") && player.civilOn == true)
        {
            collision.gameObject.SetActive(false);
            timeManager.LoserPanel();
            Time.timeScale = 0f;
        }
    }
}
