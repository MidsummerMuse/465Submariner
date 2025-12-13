using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool paused = false;
    private UIManager UI = null;

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject TitleScreen;
    [SerializeField] private GameObject StartButton;

    public bool gameOver = true;
    public bool gamePaused = false;

    void Start()
    {
        UI = FindObjectOfType<UIManager>();
        StartButton.SetActive(true);
    }

    void Update()
    {
        // Pause the game with 'P'
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = gamePaused ? 1 : 0;
            gamePaused = !gamePaused;
        }

        // Start the game with enter
        if (gameOver && Input.GetKeyDown(KeyCode.Return))
        {
            StartTheGame();
        }
        


    }

    public void StartTheGame()
    {
        gameOver = false;
        

        //camera follow the player
        

        TitleScreen.SetActive(false);
        StartButton.SetActive(false);
    }

    public void EndTheGame ()
    {
        TitleScreen.SetActive(true);
        StartButton.SetActive(true);
        gameOver = true;
    }
}