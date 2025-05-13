using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 7f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    public int damage = 10;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;


    public int maxHealth = 3;
    private int currentHealth;



    private Transform player;
    private float lastAttackTime;
    private Rigidbody2D rb;
    private bool isGrounded;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float distance = Vector2.Distance(transform.position, player.position);



        if (distance <= attackRange)
        {
            Attack();
        }
        else
        {
            MoveTowardPlayer();

            if (player.position.y > transform.position.y + 1f && isGrounded)
            {
                Jump();
            }

        }
    }
    void MoveTowardPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;  
        transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

    }
    void Attack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Debug.Log("Monster attacks!");

            lastAttackTime = Time.time;
        }
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterMovement player = collision.gameObject.GetComponent<CharacterMovement>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }

        }
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }    
   

    void Die()
    {
        Destroy(gameObject);
    }
}
    

