using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    [SerializeField] float startTime = 60f;

    float timeLeft = 0;
    bool isGameOver = false;

    //properties

    // public bool IsGameOver
    // {
    //     get { return isGameOver; }
    //     set { isGameOver = value; } 
    // } // -> tranditional way

    // public bool IsGameOver { get { return isGameOver; } } //-> fancy way
    // public bool IsGameOver { get; private set; } // -> syntax sugar
    public bool IsGameOver => isGameOver; // -> super syntax sugar

    private void Start()
    {
        timeLeft = startTime;
    }

    private void Update()
    {
        DecreaseTime();
    }

    public void ModifyTime(float amount)
    {
        if (isGameOver) return;
        timeLeft += amount;
    }

    private void DecreaseTime()
    {
        if (isGameOver) return;

        timeLeft -= Time.deltaTime;

        // to see overloads option, click in () then ctrl+shift+space
        timeText.text = timeLeft.ToString("F1");//display 1 decimal

        if (timeLeft <= 0)
        {
            gameOver();
        }
    }

    private void gameOver()
    {
        isGameOver = true;
        playerController.enabled = false; // disable a conponent
        gameOverText.SetActive(true); // activate a Object
        Time.timeScale = 0.1f; // slow down everything in game
    }
}
