using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 5.5f;
    [SerializeField] private GameObject EnemyBoomPrefab;
    private UIManager UI;
    private GameManager GM;
    [SerializeField] private AudioClip explosionClip;
    // Start is called before the first frame update
    void Start()
    {
        UI = GameObject.Find("UIManager").GetComponent<UIManager>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //move
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        //cleanup
        if (transform.position.y < -7.0f)
        {
            //destroy isnt efficient, reuse enemy
            // local variable used here only=
            float xPos = Random.Range(-8.25f, 8.25f); //inclusive/inclusive

            transform.position = new Vector3(xPos, 7.0f, 0);

            //  int xCol = Random.Range(-8, 8); //inclusive/exclusive

        }
        //update
        if (GM.gameOver == true)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("torpedo"))
        {


           

            Destroy(collision.gameObject);
            Destroy(gameObject); //enemy
        }
        else if (collision.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            // don't want to destroy on first hit

            Player P = collision.GetComponent<Player>();
            if (P != null)
            {
                P.Damage();
            }


        }
        
        Destroy(gameObject);
    }
}
