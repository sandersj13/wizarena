using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public Transform player;
    public float moveSpeed = 2f;
    public float chaseRange = 10f;
    public float attackRange = 1.5f;
    public float attackCooldown = 1.5f;

    private float lastAttackTime;
    // Start is called before the first frame update
    void Start()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseRange && distance > attackRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
        else if (distance <= attackRange)
        {
            transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            if (Time.time > lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;

            }
        }

        
    }

    // Update is called once per frame
    void Attack()
    {
        Debug.Log("Zombie attacks!");

            CharacterMovement health = player.GetComponent<CharacterMovement>();
        if (health != null)
        {
            health.TakeDamage(10);
        }
    }
}
