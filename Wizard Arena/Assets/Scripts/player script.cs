using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    
    public float jumpForce = 10f;
    

    private float moveInput;
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private int jumpCount;
    public int maxJumps = 2;

    public Transform groundCheck;
    public float checkRadius = 0.1f;
    public LayerMask groundLayer;
    private bool isGrounded;

    public float FireballSpeed = 20.0f;
    public GameObject FireballPrefab;

    public GameController controller;

    private bool isFacingRight = true;

    public Transform firePoint;
    public GameObject Freezeballprefab;

    public int maxHealth = 100;
    public int currentHealth;
    public GameObject deathEffect;

    private Animator animator;

    


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
       
    }

    // Update is called once per frame
    void Update()
    {



        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);


        if (isGrounded)
        {
            jumpCount = maxJumps;

        }

        // Jump input
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount > 0)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount--;
        }


        moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireShot();
        }

        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }

        if (!isFacingRight)
        {
            Vector3 scale = FireballPrefab.transform.localScale;
            scale.x *= -1;
            FireballPrefab.transform.localScale = scale;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ShootFreezeBall();
        }
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    
       
    

    void OnTriggerCollision2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.CompareTag("charge"))
        {
            Destroy(otherObject.gameObject);
        }
        

        
    }

    void fireShot()
    {
        GameObject Fireball = (GameObject)Instantiate(FireballPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = Fireball.GetComponent<Rigidbody2D>();

        float direction = isFacingRight ? 1f : -1f;
        rb.velocity = new Vector2(FireballSpeed * direction, 0);

        if (!isFacingRight)
        {
            Vector3 scale = Fireball.transform.localScale;
            scale.x *= -1;
            Fireball.transform.localScale = scale;
        }
    }

    void ShootFreezeBall()
    {
        GameObject freezeBall = Instantiate(Freezeballprefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = freezeBall.GetComponent<Rigidbody2D>();

        float direction = isFacingRight ? 1f : -1f;
        rb.velocity = new Vector2(FireballSpeed * direction, 0);

        if (!isFacingRight)
        {
            Vector3 scale = freezeBall.transform.localScale;
            scale.x *= -1;
            freezeBall.transform.localScale = scale;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0 )
        {
            Die();
        }
    }

    void Die()
    {
        if ( animator != null)
        {
            animator.SetTrigger("Die");
        }

        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        StartCoroutine(HandleDeath());
    }

    IEnumerator HandleDeath()
    {
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);

        if (controller != null)
        {
            controller.GameOver();
        }
    }

  
    



}

