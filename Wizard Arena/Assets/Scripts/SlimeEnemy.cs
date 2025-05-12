using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class SlimeEnemy : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 3f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [Header("Combat")]
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    public int damage = 10;

    [Header("Health")]
    public int maxHealth = 3;
    private int currentHealth;

    [Header("Freeze Effect")]
    private bool isFrozen = false;
    private float originalSpeed;

    private float lastAttackTime;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Transform player;
    private GameManager gameManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        gameManager = FindObjectOfType<GameManager>();
        currentHealth = maxHealth;
        originalSpeed = moveSpeed;
    }

    void Update()
    {
        if (isFrozen || player == null) return;

        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            TryAttack();
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
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }

    void TryAttack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Debug.Log("Slime attacks!");
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
            CharacterMovement playerMovement = collision.gameObject.GetComponent<CharacterMovement>();
            if (playerMovement != null)
            {
                playerMovement.TakeDamage(damage);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameManager?.EnemyDefeated();
        Destroy(gameObject);
    }

    public void Freeze(float duration)
    {
        if (!isFrozen)
            StartCoroutine(FreezeCoroutine(duration));
    }

    private IEnumerator FreezeCoroutine(float duration)
    {
        isFrozen = true;
        moveSpeed = 0;
        spriteRenderer.color = Color.cyan;

        yield return new WaitForSeconds(duration);

        moveSpeed = originalSpeed;
        spriteRenderer.color = Color.white;
        isFrozen = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
