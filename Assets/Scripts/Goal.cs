using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager GM;
    private UIManager UM;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        UM = GameObject.Find("UIManager").GetComponent<UIManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {





            Destroy(gameObject);
            GM.gameOver = true;
            GM.EndTheGame();
            UM.ShowTitleScreen();
        }
    }
    }
