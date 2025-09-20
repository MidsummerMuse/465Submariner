using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float speed = 5.5f;
    private float fireRate = 0.25f; //cooldown
    private float canFire = 0.05f;

    [SerializeField] private GameObject LaserPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Shoot();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
    }

    private void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > canFire)
            {
                Instantiate(LaserPrefab, transform.position + new Vector3(0.9f, -0.2f, 0), Quaternion.Euler(0, 0, 90));

                canFire = Time.time + fireRate;
            }
        }
    }


}
