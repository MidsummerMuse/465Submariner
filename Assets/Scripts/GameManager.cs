using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject TitleScreen;
    [SerializeField] private GameObject StartButton;

    public bool gameOver = true;
    public bool gamePaused = false;

    void Update()
    {
        // Pause the game with 'P'
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = gamePaused ? 1 : 0;
            gamePaused = !gamePaused;
        }

        // Start the game with spacebar
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            StartTheGame();
        }
    }

    public void StartTheGame()
    {
        gameOver = false;  
        Instantiate(Player, new Vector3(0, 0, 0), Quaternion.identity);
        TitleScreen.SetActive(false);
        StartButton.SetActive(false);
    }
}