using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float speed = 5.5f;
    private float fireRate = 0.25f; //cooldown
    private float canFire = 0.05f;
    public float jump;
    [SerializeField] private GameObject LaserPrefab = null;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Shoot();

        Lift();

    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        
    }

    private void Lift()
    {
      if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump)); 
        }
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (Time.time > canFire)
            {
                Instantiate(LaserPrefab, transform.position + new Vector3(0.9f, -0.2f, 0), Quaternion.Euler(0, 0, 90));

                canFire = Time.time + fireRate;
            }
        }
    }


}
