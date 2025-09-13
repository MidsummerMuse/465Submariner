using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public bool gameOver = true;
    public bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!gamePaused)
            {
                Time.timeScale = 0;
                gamePaused = true;

            }
            else
            {
                Time.timeScale = 1;
                gamePaused = false;
            }
        }
    }
}
