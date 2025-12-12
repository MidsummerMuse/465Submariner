using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float speed = 5.5f;
    private float fireRate = 0.25f; //cooldown
    private float canFire = 0.05f;
    private float JumpCharges = 3;
    private float PropelCharges = 3;
    private float canRecharge = 0.0f;
    private float rechargeRate = 1.0f;
    public float keysHeld = 0;
    float horizontalInput;
    float moveSpeed = 5f;
    float jumpPower = 4f;
    bool isFacingRight = true;
    private GameManager GM;

    private bool isGrounded = false;

    private bool isJumping;
    public float jump;
    [SerializeField] private GameObject LaserPrefab = null;
    private Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Shoot();

        Lift();

        Propel();
       
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();

        if(Input.GetButtonDown("Jump") && !isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
    }


    private void FixedUpdate()
    {
   
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        

        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        
    }

    private void Lift()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (JumpCharges>0))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));

            JumpCharges--;

            

        }

     

      
        

    }

    public void RechargeJump()
    {
        JumpCharges = 3;

    }

    public void RechargePropel()
    {
        PropelCharges = 3; 
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

    private void Propel()
    {
        if(Input.GetKeyDown(KeyCode.P) && (PropelCharges > 0))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * 200);
        }

        if (Input.GetKeyDown(KeyCode.O) && (PropelCharges > 0))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed * 200);
        }
    }

    public void Damage()
    {
        Destroy(gameObject);
        GM.gameOver = true;
    }



}
