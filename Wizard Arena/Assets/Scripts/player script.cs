using System.Collections;
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

    public int maxHealth = 10;
    public int health;
   

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        animator = GetComponent<Animator>();
       
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

        if (!isDashing)
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        }

        

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

        if (Input.GetKeyDown(KeyCode.D)&& canDash && moveInput != 0)
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        float dashDirection = isFacingRight ? 1f : -1f;
        rb.velocity = new Vector2(moveInput * dashForce, 0f);

        yield return new WaitForSeconds(dashDuration);

        rb.gravityScale = originalGravity;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

        TrailRenderer trail = GetComponent<TrailRenderer>();
        if (trail != null)
        {
            trail.emitting = true;
        }
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    
       
    

    void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.gameObject.CompareTag("charge"))
        {
            Destroy(otherObject.gameObject);
        }
        

        
    }

    void fireShot()
    {
        GameObject Fireball = Instantiate(FireballPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = Fireball.GetComponent<Rigidbody2D>();

        float direction = isFacingRight ? 1f : -1f;
        rb.velocity = new Vector2(FireballSpeed * direction, 0);

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

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0 )
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

