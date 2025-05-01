using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSlimeScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float jumpForce = 7f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    public int damage = 10;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public Transform edgeCheck;
    public float edgeCheckDistance = 0.1f;


    private Transform player;
    private float lastAttackTime;
    private Rigidbody2D rb;
    private bool isGrounded;

    public float detectionRange = 4f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= detectionRange)
        {
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
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
            
    }
    void MoveTowardPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        bool isGroundAhead = Physics2D.Raycast(edgeCheck.position, Vector2.down, edgeCheckDistance, groundLayer);

        if (isGroundAhead)
        {
            rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
