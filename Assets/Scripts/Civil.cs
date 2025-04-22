using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civil : MonoBehaviour
{
    GameObject civil;

    Player_Controller player;
    TimeManager timeManager;

    private void Start()
    {
        player = FindAnyObjectByType<Player_Controller>();
        timeManager = FindAnyObjectByType<TimeManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BanderaWin") && player.civilOn == true)
        {
            timeManager.LoserPanel();
            collision.gameObject.SetActive(false);
            Time.timeScale = 0f;
        }
    }
}
